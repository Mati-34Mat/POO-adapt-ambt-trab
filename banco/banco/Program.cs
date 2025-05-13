using System;

namespace banco
{
    class Program
    {
        public class CuentaBancaria
        {
            private int numeroCuenta;
            private int saldo;
            private string titular;

            public CuentaBancaria(int numeroCuenta, int saldo, string titular)
            {
                this.numeroCuenta = numeroCuenta;
                this.saldo = saldo;
                this.titular = titular;
            }

            public int ObtenerSaldo()
            {
                return saldo;
            }

            public void ModificarSaldo(int saldo)
            {
                this.saldo = saldo;
            }

            public int ObtenerNumeroCuenta()
            {
                return numeroCuenta;
            }
        }

        public class Banco
        {
            private CuentaBancaria[] cuentas = new CuentaBancaria[100];
            private int cantidadCuentas = 0;

            public void AgregarCuenta(CuentaBancaria cuenta)
            {
                if (cantidadCuentas < 100)
                {
                    cuentas[cantidadCuentas] = cuenta;
                    cantidadCuentas++;
                }
            }

            private CuentaBancaria BuscarCuenta(int numeroCuenta)
            {
                for (int i = 0; i < cantidadCuentas; i++)
                {
                    if (cuentas[i].ObtenerNumeroCuenta() == numeroCuenta)
                        return cuentas[i];
                }
                return null;
            }

            public void Depositar(int numeroCuenta, int monto)
            {
                CuentaBancaria cuenta = BuscarCuenta(numeroCuenta);
                if (cuenta != null && monto > 0)
                {
                    cuenta.ModificarSaldo(cuenta.ObtenerSaldo() + monto);
                }
            }

            public void Extraer(int numeroCuenta, int monto)
            {
                CuentaBancaria cuenta = BuscarCuenta(numeroCuenta);
                if (cuenta != null && monto > 0 && cuenta.ObtenerSaldo() >= monto)
                {
                    cuenta.ModificarSaldo(cuenta.ObtenerSaldo() - monto);
                }
            }

            public bool Transferencia(int cuentaOrigen, int monto, int cuentaDestino)
            {
                CuentaBancaria origen = BuscarCuenta(cuentaOrigen);
                CuentaBancaria destino = BuscarCuenta(cuentaDestino);

                if (origen != null && destino != null && monto > 0 && origen.ObtenerSaldo() >= monto)
                {
                    origen.ModificarSaldo(origen.ObtenerSaldo() - monto);
                    destino.ModificarSaldo(destino.ObtenerSaldo() + monto);
                    return true;
                }

                return false;
            }
        }

        static void Main(string[] args)
        {
            Banco banco = new Banco();

            CuentaBancaria c1 = new CuentaBancaria(1, 1000, "Juan");
            CuentaBancaria c2 = new CuentaBancaria(2, 500, "Ana");

            banco.AgregarCuenta(c1);
            banco.AgregarCuenta(c2);

            banco.Depositar(1, 200);
            banco.Extraer(2, 100);

            bool exito = banco.Transferencia(1, 300, 2);
            Console.WriteLine($"Transferencia exitosa: {exito}");
        }
    }
}
