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

public class ItemNode
{
    public Item Data { get; }
    public ItemNode Next { get; set; }

    public ItemNode(Item item)
    {
        Data = item;
        Next = null;
    }
}

public class ManajemenInventori
{
    private ItemNode head;

    public void TambahItem(Item item)
    {
        var node = new ItemNode(item);
        if (head == null)
        {
            head = node;
        }
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

    public bool HapusItem(string nama)
    {
        ItemNode current = head, prev = null;

        while (current != null)
        {
            if (current.Data.Nama == nama)
            {
                if (prev == null)
                {
                    head = current.Next;
                }
                else
                {
                    prev.Next = current.Next;
                }
                return true;
            }
            prev = current;
            current = current.Next;
        }
        return false;
    }

    public string TampilkanInventori()
    {
        ItemNode current = head;
        string result = "";

        while (current != null)
        {
            result += $"{current.Data.Nama}; {current.Data.Kuantitas}\n";
            current = current.Next;
        }

        return result.TrimEnd();
    }
}