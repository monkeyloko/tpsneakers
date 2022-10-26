namespace TPSNEAKERS.Models;
public class CarritoxProducto{
    private int _ID_CARRITO;
    private int _ID_Producto;

    public CarritoxProducto(int ID_CARRITO, int ID_Producto){
        _ID_CARRITO = ID_CARRITO;
        _ID_Producto = ID_Producto;
    }

    public int ID_CARRITO{
        get{
            return _ID_CARRITO;
        } set{
            _ID_CARRITO = value;
        }
    }
    public int ID_Producto{
        get{
            return _ID_Producto;
        } set{
            _ID_Producto = value;
        }
    }
    
} 