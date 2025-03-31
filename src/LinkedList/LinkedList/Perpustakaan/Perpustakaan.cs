using System;
using System.Dynamic;
namespace LinkedList.Perpustakaan;

public class Buku
{
    public string Judul { get; }
    public string Penulis { get; }
    public int Tahun { get; }

    public Buku(string judul, string penulis, int tahun)
    {
        Judul = judul;
        Penulis = penulis;
        Tahun = tahun;
    }
}

public class BukuNode
{
    public Buku Data { get; }
    public BukuNode Next { get; set; }
    public BukuNode(Buku buku)
    {
        Data = buku;
        Next = null;
    }
}

public class KoleksiPerpustakaan
{
    private BukuNode head;

    public void TambahBuku(Buku buku)
    {
        var node = new BukuNode(buku);
        if (head == null) head = node;
        else
        {
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = node;
        }
    }
    public bool HapusBuku(string judul)
    {
        BukuNode current = head, prev = null;

        while (current != null)
        {
            if (current.Data.Judul == judul)
            {
                if (prev == null) head = current.Next;
                else prev.Next = current.Next;
                return true;
            }
            prev = current;
            current = current.Next;
        }
        return false;
    }

    public Buku[] CariBuku(string kataKunci)
    {
        BukuNode current = head;
        int count = 0;

        while (current != null)
        {
            if (current.Data.Judul.Contains(kataKunci, StringComparison.OrdinalIgnoreCase)) count++;
            current = current.Next;
        }

        Buku[] hasil = new Buku[count];
        current = head;
        int index = 0;

        while (current != null)
        {
            if (current.Data.Judul.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
            {
                hasil[index++] = current.Data;
            }
            current = current.Next;
        }
        return hasil;
    }
    public string TampilkanKoleksi()
    {
        BukuNode current = head;
        string result = "";

        while (current != null)
        {
            result += $"\"{current.Data.Judul}\"; {current.Data.Penulis}; {current.Data.Tahun}\n";
            current = current.Next;
        }

        return result.TrimEnd();
    }
}
