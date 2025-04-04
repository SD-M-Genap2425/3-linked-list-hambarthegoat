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
    public Karyawan Karyawan { get; set; }
    public KaryawanNode Next { get; set; }
    public KaryawanNode Prev { get; set; }

    public KaryawanNode(Karyawan karyawan)
    {
        Karyawan = karyawan;
        Next = null;
        Prev = null;
    }
}

public class KaryawanResultNode
{
    public Karyawan Data { get; }
    public KaryawanResultNode Next { get; set; }

    public KaryawanResultNode(Karyawan karyawan)
    {
        Data = karyawan;
        Next = null;
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
            if (current.Karyawan.NomorKaryawan == nomorKaryawan) 
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
        KaryawanResultNode resultHead = null;
        KaryawanResultNode resultTail = null;
        int count = 0;

        var current = head;
        while (current != null)
        {
            if (current.Karyawan.Nama.Contains(kataKunci, StringComparison.OrdinalIgnoreCase) || 
                current.Karyawan.Posisi.Contains(kataKunci, StringComparison.OrdinalIgnoreCase)) 
            {
                var resultNode = new KaryawanResultNode(current.Karyawan); 
                if (resultHead == null)
                {
                    resultHead = resultTail = resultNode;
                }
                else
                {
                    resultTail.Next = resultNode;
                    resultTail = resultNode;
                }
                count++;
            }
            current = current.Next;
        }

        var resultArray = new Karyawan[count];
        var resultCurrent = resultHead;
        int index = 0;

        while (resultCurrent != null)
        {
            resultArray[index++] = resultCurrent.Data;
            resultCurrent = resultCurrent.Next;
        }

        return resultArray;
    }

    public string TampilkanDaftar()
    {
        var current = tail;
        string result = "";
        while (current != null)
        {
            result += $"{current.Karyawan.NomorKaryawan}; {current.Karyawan.Nama}; {current.Karyawan.Posisi}\n"; 
            current = current.Prev;
        }
        return result.TrimEnd();
    }
}