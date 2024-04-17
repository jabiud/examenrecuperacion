using System.Numerics;

namespace examenRecuperacion
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}

#include <iostream>
#include <string>
#include <vector>

using namespace std;

// Definición de la estructura Cliente
struct Cliente
{
    string nombre;
    int edad;
    string tipo; // "colegio", "adulto mayor", "adulto"
    int cantidad_personas;
    double descuento;
    double monto_pagar;
};

// Definición de la estructura Ruta
struct Ruta
{
    string nombre;
    double precio;
};

// Función para calcular el descuento basado en la cantidad de personas
double calcularDescuento(int cantidad_personas)
{
    if (cantidad_personas == 1)
        return 0.0;
    else if (cantidad_personas >= 2 && cantidad_personas <= 7)
        return 0.08;
    else if (cantidad_personas >= 8 && cantidad_personas <= 16)
        return 0.13;
    else
        return 0.15;
}

// Función para calcular el descuento adicional según el tipo de cliente
double calcularDescuentoAdicional(string tipo_cliente)
{
    if (tipo_cliente == "colegio")
        return 0.07;
    else if (tipo_cliente == "adulto mayor")
        return 0.05;
    else
        return 0.0;
}

int main()
{
    // Definir las rutas
    Ruta rutas[3] = {
        {"Sacsayhuaman – Puka Pukara – Tambomachay", 100.0},
        {"Tipon - Lucre - Piquillaqta", 120.0},
        {"Ollantaytambo - Machupicchu", 150.0}
    };

    // Solicitar la cantidad de clientes
    int cantidad_clientes;
    cout << "Ingrese la cantidad de clientes: ";
    cin >> cantidad_clientes;

    // Vector para almacenar los clientes
    vector<Cliente> clientes(cantidad_clientes);

    // Ingresar los datos de cada cliente
    for (int i = 0; i < cantidad_clientes; ++i)
    {
        cout << "Cliente " << i + 1 << ":" << endl;
        cout << "Nombre: ";
        cin >> clientes[i].nombre;
        cout << "Edad: ";
        cin >> clientes[i].edad;
        cout << "Tipo de cliente (colegio, adulto mayor, adulto): ";
        cin >> clientes[i].tipo;
        cout << "Cantidad de personas: ";
        cin >> clientes[i].cantidad_personas;

        // Calcular descuento
        double descuento_base = calcularDescuento(clientes[i].cantidad_personas);
        double descuento_adicional = calcularDescuentoAdicional(clientes[i].tipo);
        double descuento_total = descuento_base + descuento_adicional;
        double precio_ruta = 0.0; // Precio de la ruta seleccionada

        // Seleccionar la ruta y calcular el monto a pagar
        cout << "Seleccione la ruta (1, 2, 3): ";
        int opcion_ruta;
        cin >> opcion_ruta;

        // Validar la opción de ruta
        if (opcion_ruta >= 1 && opcion_ruta <= 3)
        {
            precio_ruta = rutas[opcion_ruta - 1].precio;
        }
        else
        {
            cout << "Opción de ruta no válida. Se asignará precio cero." << endl;
        }

        clientes[i].monto_pagar = precio_ruta * (1 - descuento_total);

        cout << endl;
    }

    // Mostrar la lista de clientes y el acumulado del Importe Pago de clientes
    double total_acumulado = 0.0;
    cout << "Lista de clientes:" << endl;
    for (int i = 0; i < cantidad_clientes; ++i)
    {
        cout << "Nombre: " << clientes[i].nombre << ", Monto a pagar: S/." << clientes[i].monto_pagar << endl;
        total_acumulado += clientes[i].monto_pagar;
    }
    cout << "Total acumulado: S/." << total_acumulado << endl;

    return 0;
}
