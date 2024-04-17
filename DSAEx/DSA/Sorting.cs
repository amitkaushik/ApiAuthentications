namespace DSAEx.DSA
{
    public  static class Sorting
    {
        public static async Task<IList<int>> BubbolShort(IList<int> list)
        {
            IList<int> result = list;
            await Task.Run(() =>
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    for (int j = 0; j < list.Count()-i-1; j++)
                    {
                        if (list[j] > list[j + 1])
                        {
                            Swap(ref result, j, j + 1);
                        }
                    }
                }
            });

            return result;
        }


        public static async Task<IList<int>> SelectionShort(IList<int> list)
        {
            IList<int> result = list;
            await Task.Run(() =>
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    int min_idx = i;
                    for (int j = i + 1; j < list.Count(); j++)                    
                        if (list[j] < list[min_idx])
                            min_idx = j;                    
                    Swap(ref result, i, min_idx);
                }
            });

            return result;
        }

        public static void Swap(ref IList<int> list, int a, int b)
        {
            list[a] = list[a] + list[b]; //2+3=5
            list[b] = list[a] - list[b];//5-3 = 2
            list[a] = list[a] - list[b];//5-2=3

        }

    }
}
