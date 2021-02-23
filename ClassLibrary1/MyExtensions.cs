namespace ClassLibrary1
{
    public static class MyExtensions
    {
        /// <summary>
        /// first argument is the object we are extending
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsBig(this Circle c)
        {
            return c.Radius > 10;
        }
    }
}
