using OilfieldCalc3.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tubulars;
using Tubulars.DrillstringTubulars;
using Tubulars.WellboreTubulars;
using Xamarin.Forms;

namespace OilfieldCalc3.Services
{
    /// <summary>
    /// The Dataservice is used to access the database tables for the required objects.
    /// CRUD operations are done through this.
    /// </summary>
    public class DataService : IDataService
    {
        /// <summary>
        /// Uses Lazy class to delay initialization of the database until it's first accessed.
        /// </summary>
        private static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        private static SQLiteAsyncConnection Database => lazyInitializer.Value;
        private static bool initialized = false;

        /// <summary>
        /// Class constructor, initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        public DataService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        /// <summary>
        /// Initializes the database tables and creates them if required.
        /// </summary>
        private async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(WellboreTubularBase).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(WellboreTubularBase)).ConfigureAwait(false);
                }

                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(DrillstringTubularBase).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(DrillstringTubularBase)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        /// <summary>
        /// Gets all items from a database table. Gets the items sorted asynchronous.
        /// </summary>
        /// <typeparam name="T">Generic object representing a database table.</typeparam>
        /// <returns>Task<IEnumerable<T>> collection of ITubular Items.</returns>
        public async Task<List<T>> GetItemsSortedAsync<T>() where T : ITubular, new()
        {
            List<T> tubularList = await Database.Table<T>().ToListAsync().ConfigureAwait(false);
            ITubular tempTubular;

            //Bubble sort the items by the integer column: ItemSortOrder
            for(int j=0;j<=tubularList.Count-2;j++)
            {
                for (int i=0;i<=tubularList.Count-2;i++)
                {
                    if(tubularList[i].ItemSortOrder>tubularList[i+1].ItemSortOrder)
                    {
                        tempTubular = tubularList[i + 1];
                        tubularList[i + 1] = tubularList[i];
                        tubularList[i] = (T)tempTubular;
                    }
                }
            }

            return tubularList;
        }

        /// <summary>
        /// Gets a single ITubular item from the database Gets the item asynchronous.
        /// </summary>
        /// <typeparam name="T">Generic object representing a database table.</typeparam>
        /// <param name="id">The unique itemID number(PRIMARY KEY).</param>
        /// <returns>ITubular item.</returns>
        public Task<T> GetItemAsync<T>(int id) where T : ITubular, new()
        {
            return Database.Table<T>().Where(i => i.ItemID == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Save or update an item as a record to the database. Requires an ITubular object. Saves the item asynchronous.
        /// If item is a new record, SortOrder is updated automatically.
        /// </summary>
        /// <param name="item">ITubular object.</param>
        /// <returns>Task<int> Number of records created or updated</returns>
        public async Task<int> SaveItemAsync(ITubular item)
        {
            //If it is not a new record we are updating
            if (item.ItemID != 0)
            {
                return await Database.UpdateAsync(item).ConfigureAwait(false);
            }

            //Must be a new record because ItemID is 0
            else
            {
                //populate the SortOrder field
                //Get record count and add 1 to it.
                item.ItemSortOrder = await GetRecordCountAsync(item).ConfigureAwait(false) + 1;

                return await Database.InsertAsync(item).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Returns the number of records contained in a Table
        /// </summary>
        /// <param name="item">An ITubular object</param>
        /// <returns>Number of records in the referenced table based on item.</returns>
        private async Task<int> GetRecordCountAsync(ITubular item)
        {
            if(item.GetType().BaseType==typeof(DrillstringTubularBase))
                return await Database.Table<DrillPipe>().CountAsync().ConfigureAwait(false);

            if (item.GetType().BaseType == typeof(WellboreTubularBase))
                return await Database.Table<Casing>().CountAsync().ConfigureAwait(false);

            return 0;
        }

        /// <summary>
        /// Removes and item from the database. Deletes the item asynchronous.
        /// </summary>
        /// <param name="item">An ITubular item.</param>
        /// <returns>Task<int> Number of records deleted</returns>
        public async Task<int> DeleteItemAsync(ITubular item)
        {
            //TODO: check for consecutive sort order and repair as needed...
            var returnValue = Database.DeleteAsync(item);
            var itemType = item.GetType().BaseType;

            if (item.GetType().BaseType == typeof(DrillstringTubularBase))
                await RepairSortAsync<DrillPipe>().ConfigureAwait(false);

            if (item.GetType().BaseType == typeof(WellboreTubularBase))
                await RepairSortAsync<Casing>().ConfigureAwait(false);

            return 1;
        }

        /// <summary>
        /// Clears all data from table T
        /// </summary>
        /// <typeparam name="T">Generic parameter of ITubular</typeparam>
        /// <returns>Task<int>Number of records deleted</returns>
        public Task<int> ClearTable<T>() where T : ITubular
        {
            return Database.DeleteAllAsync<T>();
        }

        /// <summary>
        /// Gets a list of items in a table and reassigns sortOrder values
        /// in a consecutive manner, eliminating any gaps usually created
        /// after a delete record operation.
        /// </summary>
        /// <typeparam name="T">Generic representing a database table</typeparam>
        /// <returns>true when complete</returns>
        private async Task<bool> RepairSortAsync<T>() where T : ITubular, new()
        {
            List<T> tubularList = await Database.Table<T>().ToListAsync().ConfigureAwait(false);
            tubularList.OrderBy(x => x.ItemSortOrder);

            int count = 1;
            foreach (T tubular in tubularList)
            {
                tubular.ItemSortOrder = count++;
                await SaveItemAsync(tubular).ConfigureAwait(false);
            }
            return true;
        }
    }
}
