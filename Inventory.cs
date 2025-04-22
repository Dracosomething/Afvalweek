using Godot;
using System;

public partial class Inventory : Node
{
    private int capasity;
    private int contents;

    public int _contents { get { return contents; } }
    public int _capasity { get { return capasity; } }

    public Inventory(int capasity)
    {
        this.capasity = capasity;
        this.contents = 0;
    }

    public bool addTrash()
    {
        int oldSize = contents;
        incrementContents(1);
        return contents > oldSize;
    }

    public bool addTrash(int amount)
    {
        int oldSize = contents;
        incrementContents(amount);
        return contents > oldSize;
    }

    public bool removeTrash()
    {
        int oldSize = contents;
        decreaseContents(1);
        return contents < oldSize;
    }

    public bool removeTrash(int amount)
    {
        int oldSize = contents;
        decreaseContents(amount);
        return contents < oldSize;
    }

    public bool upgradeCapasity(int amount)
    {
        int oldCapasity = capasity;
        capasity += amount;
        return capasity > oldCapasity;
    }

    private void incrementContents(int amount)
    {
        if (this.contents < this.capasity)
        {
            this.contents += amount;
            if (this.contents > this.capasity)
            {
                this.contents = capasity;
            }
        }
    }

    private void decreaseContents(int amount)
    {
        this.contents -= amount;
        if (this.contents < 0)
        {
            this.contents = 0;
        }
    }
}
