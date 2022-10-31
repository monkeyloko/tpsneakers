namespace TPSNEAKERS.Models;
public class Usuario
{
    private int _ID_USUARIO;
    private string _Nombre;

    public Usuario(int ID_USUARIO, string Nombre)
    {
        _ID_USUARIO = ID_USUARIO;
        _Nombre = Nombre;
    }
    public Usuario(string Nombre){
        _Nombre = Nombre;
    }

    public int ID_USUARIO
    {
        get
        {
            return _ID_USUARIO;
        }
        set
        {
            _ID_USUARIO = value;
        }
    }
    public string Nombre
    {
        get
        {
            return _Nombre;
        }
        set
        {
            _Nombre = value;
        }
    }
    public Usuario()
    {

    }
}