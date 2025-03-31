namespace LinkedList.Inventori;

public class Item
{
    public string Nama { get; }
    public int Kuantitas { get; }

    public Item(string nama, int kuantitas)
    {
        Nama = nama;
        Kuantitas = kuantitas;
    }
}

public class ManajemenInventori
{
    private LinkedList<Item> inventori = new LinkedList<Item>();

    public void TambahItem(Item item)
    {
        inventori.AddLast(item);
    }

    public bool HapusItem(string nama)
    {
        var current = inventori.First;
        while (current != null)
        {
            if (current.Value.Nama == nama)
            {
                inventori.Remove(current);
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public string TampilkanInventori()
    {
        string result = "";
        foreach (var item in inventori)
        {
            result += $"{item.Nama}; {item.Kuantitas}\n";
        }
        return result.TrimEnd();
    }
}