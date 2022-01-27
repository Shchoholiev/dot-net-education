using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndDelegates
{
    public class DataStorage<T>
    {
        public DataStorage(PrintData<T> function, List<T> data)
        {
            this.PrintData += function;
            this.DataList = data;
        }

        private event PrintData<T> PrintData;

        public List<T> DataList { get; set; }

        public List<T> GetFilteredData(Func<T, bool> predicate, Func<T, T> selector)
        {
            var filteredList = this.DataList.Where(predicate).Select(selector).ToList();
            return filteredList;
        }

        public void Execute(T data)
        {
            this.PrintData.Invoke(data);
        }
    }
}