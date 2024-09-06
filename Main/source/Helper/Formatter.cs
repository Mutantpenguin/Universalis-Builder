namespace Universalis
{
    public static class Formatter
    {
        public static string Modifier( float modifier )
        {
            if( modifier == 0 )
            {
                return null;
            }
            else if( modifier > 0 )
            {
                return "+" + modifier;
            }
            else
            {
                return modifier.ToString();
            }
        }
    }
}
