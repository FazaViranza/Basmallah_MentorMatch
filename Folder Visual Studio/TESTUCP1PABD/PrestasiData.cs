using System;

namespace TESTUCP1PABD
{
    /// <summary>
    /// Model data yang digunakan sebagai sumber data (Database Field) di Crystal Report.
    /// Disesuaikan dengan tabel Mahasiswa, Dosen, JenisLomba, dan PengajuanLomba.
    /// </summary>
    public class PrestasiData
    {
        public string NIM { get; set; }
        public string NamaMahasiswa { get; set; }
        public string Prodi { get; set; }
        public string NamaDosen { get; set; }
        public string NamaJenis { get; set; }
        public string NamaLomba { get; set; }
        public string Penyelenggara { get; set; }
        public string TanggalPelaksanaan { get; set; }
        public string Status { get; set; }
        public string HasilLomba { get; set; }
        public string Juara { get; set; }
    }
}
