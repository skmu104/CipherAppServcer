namespace CipherAppServer.Helpers
{
    public static class CipherCommonHelper
    {
        public const int LowerAsciiCeiling = 123;
        public const int LowerAsciiFloor = 97;
        public const int UpperAsciiCeiling = 91;
        public const int UpperAsciiFloor = 65;
        public const int AlphabetLength = 26;
        public static int GetAsciiFloor(char c)
        {
            return char.IsLower(c) ? LowerAsciiFloor : UpperAsciiFloor;
        }

        public static int GetAsciiCeiling(char c)
        {
            return char.IsLower(c) ? LowerAsciiCeiling : UpperAsciiCeiling;
        }
    }
}
