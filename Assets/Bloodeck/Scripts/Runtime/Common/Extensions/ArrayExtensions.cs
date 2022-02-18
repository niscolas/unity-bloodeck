namespace Bloodeck
{
    public static class ArrayExtensions
    {
        public static T[] NewArrayFromBetweenIndexes<T>(
            this T[] self, int startIndex, int endIndexInclusive)
        {
            T[] newArray = new T[endIndexInclusive - startIndex + 1];
            for (int i = startIndex, j = 0; i <= endIndexInclusive; i++, j++)
            {
                newArray[j] = self[i];
            }

            return newArray;
        }

        public static bool CheckIsEmpty<T>(this T[] self)
        {
            return self.Length == 0;
        }
    }
}