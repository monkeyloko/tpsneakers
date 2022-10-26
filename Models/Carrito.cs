namespace TPSNEAKERS.Models;
public class Carrito{
    private int _ID_CARRITO;
    private int _ID_USUARIO;
    
    public Carrito(int ID_CARRITO, int ID_USUARIO){
    _ID_CARRITO = ID_CARRITO;
    _ID_USUARIO = ID_USUARIO;
}
 public int ID_CARRITO{
        get{
            return _ID_CARRITO;
        } set{
            _ID_CARRITO = value;
        }
    }
    public int ID_USUARIO{  
        get{
            return _ID_USUARIO;
        } set{
            _ID_USUARIO = value;
        }
    }
}
