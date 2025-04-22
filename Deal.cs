using Godot;
using System;

public partial class Deal : Node
{
    private int price;
    private Action upgrade;

    public Deal(int price, Action upgrade) {
        this.price = price;
        this.upgrade = upgrade;
    }

    public void acceptDeal(Player player) {
        
    }

    private void dealFailed() {
        
    }
}
