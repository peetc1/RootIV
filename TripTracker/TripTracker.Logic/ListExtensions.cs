using System;
using System.Collections.Generic;

namespace TripTracker.Logic
{
    public static class ListExtensions
    {
        public static void Replace<T>(this List<T> list, Predicate<T> predicate, T replaceWIth)
        {
            var index = list.FindIndex(predicate);
            list[index] = replaceWIth;
        }
    }
}
