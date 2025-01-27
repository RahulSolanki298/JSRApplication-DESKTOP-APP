using LocalApplication.Helpers;

namespace LocalApplication
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            SeedData seedData = new SeedData();

            if (seedData.CheckDataAvailble() != true)
            {
                Application.Run(new CertificateUpload());
            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }
}