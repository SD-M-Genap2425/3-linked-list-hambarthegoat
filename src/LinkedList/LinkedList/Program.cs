using System;
using LinkedList.Perpustakaan;
using LinkedList.ManajemenKaryawan;
using LinkedList.Inventori;
namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        // Soal Perpustakaan
            Console.WriteLine("=== Perpustakaan ===");
            var perpustakaan = new KoleksiPerpustakaan();
            perpustakaan.TambahBuku(new Buku("The Hobbit", "J.R.R. Tolkien", 1937));
            perpustakaan.TambahBuku(new Buku("1984", "George Orwell", 1949));
            perpustakaan.TambahBuku(new Buku("The Catcher in the Rye", "J.D. Salinger", 1951));

            Console.WriteLine("Koleksi Buku:");
            Console.WriteLine(perpustakaan.TampilkanKoleksi());

            Console.WriteLine("\nCari Buku dengan kata kunci 'The':");
            var hasilCari = perpustakaan.CariBuku("The");
            foreach (var buku in hasilCari)
            {
                Console.WriteLine($"\"{buku.Judul}\"; {buku.Penulis}; {buku.Tahun}");
            }

            Console.WriteLine("\nHapus Buku '1984':");
            perpustakaan.HapusBuku("1984");
            Console.WriteLine(perpustakaan.TampilkanKoleksi());

        // Soal ManajemenKaryawan
            Console.WriteLine("\n=== Manajemen Karyawan ===");
            var daftarKaryawan = new DaftarKaryawan();
            daftarKaryawan.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
            daftarKaryawan.TambahKaryawan(new Karyawan("002", "Jane Doe", "HR"));
            daftarKaryawan.TambahKaryawan(new Karyawan("003", "Bob Smith", "IT"));

            Console.WriteLine("Daftar Karyawan:");
            Console.WriteLine(daftarKaryawan.TampilkanDaftar());

            Console.WriteLine("\nCari Karyawan dengan kata kunci 'Doe':");
            var hasilCariKaryawan = daftarKaryawan.CariKaryawan("Doe");
            foreach (var karyawan in hasilCariKaryawan)
            {
                Console.WriteLine($"{karyawan.NomorKaryawan}; {karyawan.Nama}; {karyawan.Posisi}");
            }

            Console.WriteLine("\nHapus Karyawan '002':");
            daftarKaryawan.HapusKaryawan("002");
            Console.WriteLine(daftarKaryawan.TampilkanDaftar());

        // Soal Inventori
            Console.WriteLine("\n=== Inventori ===");
            var inventori = new ManajemenInventori();
            inventori.TambahItem(new Item("Apple", 50));
            inventori.TambahItem(new Item("Orange", 30));
            inventori.TambahItem(new Item("Banana", 20));

            Console.WriteLine("Daftar Inventori:");
            Console.WriteLine(inventori.TampilkanInventori());

            Console.WriteLine("\nHapus Item 'Orange':");
            inventori.HapusItem("Orange");
            Console.WriteLine(inventori.TampilkanInventori());

    }
}
