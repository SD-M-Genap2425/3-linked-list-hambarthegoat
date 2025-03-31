﻿namespace LinkedList.ManajemenKaryawan;

public class Karyawan
{
    public string NomorKaryawan { get; }
    public string Nama { get; }
    public string Posisi { get; }

    public Karyawan(string nomorKaryawan, string nama, string posisi)
    {
        NomorKaryawan = nomorKaryawan;
        Nama = nama;
        Posisi = posisi;
    }
}

public class KaryawanNode
{
    public Karyawan Data { get; }
    public KaryawanNode Next { get; set; }
    public KaryawanNode Prev { get; set; }

    public KaryawanNode(Karyawan karyawan)
    {
        Data = karyawan;
        Next = null;
        Prev = null;
    }
}

public class DaftarKaryawan
{
    private KaryawanNode head;
    private KaryawanNode tail;

    public void TambahKaryawan(Karyawan karyawan)
    {
        var node = new KaryawanNode(karyawan);
        if (head == null)
        {
            head = tail = node;
        }
        else
        {
            tail.Next = node;
            node.Prev = tail;
            tail = node;
        }
    }

    public bool HapusKaryawan(string nomorKaryawan)
    {
        var current = head;
        while (current != null)
        {
            if (current.Data.NomorKaryawan == nomorKaryawan)
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    tail = current.Prev;

                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public Karyawan[] CariKaryawan(string kataKunci)
    {
        var result = new List<Karyawan>();
        var current = head;
        while (current != null)
        {
            if (current.Data.Nama.Contains(kataKunci, StringComparison.OrdinalIgnoreCase) ||
                current.Data.Posisi.Contains(kataKunci, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(current.Data);
            }
            current = current.Next;
        }
        return result.ToArray();
    }

    public string TampilkanDaftar()
    {
        var current = tail;
        string result = "";
        while (current != null)
        {
            result += $"{current.Data.NomorKaryawan}; {current.Data.Nama}; {current.Data.Posisi}\n";
            current = current.Prev;
        }
        return result.TrimEnd();
    }
}