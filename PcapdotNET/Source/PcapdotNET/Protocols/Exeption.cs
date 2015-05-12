namespace PcapdotNET.Protocols
{
    /// <summary>Class Exeption
    /// class which contains text exeption
    /// </summary>
    class Exeption
    {
        /// <summary> End File
        /// Exeption end of file
        /// </summary>
        /// <returns></returns>
        public string GetExeptionFromEndOfFile()
        {
            return "Problem with read text!";
        }

        /// <summary>File not found
        /// Exeption file not found
        /// </summary>
        /// <returns></returns>
        public string GetExeptionFileNotFound()
        {
            return "File not found!";
        }
    }
}
