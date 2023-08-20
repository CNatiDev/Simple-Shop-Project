/// <summary>
/// We use the IShopItem interface to implement the Open-Closed Principle (OCP)
/// , which is needed so that in the future, we can add other functionalities to these functions and use them in other classes that implement the IShopItem interface.
/// </summary>
public interface IShopItem
{
    void Buy();
    void DisplayOffer(bool show);
}
