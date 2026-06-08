using APPCORE;
using BusinessLogic.Connection;
using System;

namespace Operations.Analytics
{
    // ==========================================
    // KPI 1: Ingresos brutos por mes
    // ==========================================
    public class KpiMesQuery : QueryClass
    {
        public KpiMesQuery() => this.MDataMapper = new BDConnection().DBOrigen;

        // Las propiedades DEBEN estar aquí adentro para que AppCore las mapee
        public string? Mes { get; set; }
        public decimal TotalIngresos { get; set; }
        public int TotalPedidos { get; set; }

        public override string GetQuery() => @"
            SELECT 
                DATENAME(month, fecha_hora) AS Mes,
                SUM(monto_envio) AS TotalIngresos,
                COUNT(id_pedido) AS TotalPedidos
            FROM Operaciones.Pedidos
            WHERE id_estado = 1
            GROUP BY DATENAME(month, fecha_hora), MONTH(fecha_hora)
            ORDER BY MONTH(fecha_hora)";
    }

    // ==========================================
    // KPI 2: Rentabilidad por categoría
    // ==========================================
    public class KpiCategoriaQuery : QueryClass
    {
        public KpiCategoriaQuery() => this.MDataMapper = new BDConnection().DBOrigen;

        public string? Categoria { get; set; }
        public decimal TotalIngresos { get; set; }

        public override string GetQuery() => @"
            SELECT 
                c.nombre_categoria AS Categoria,
                SUM(p.monto_envio) AS TotalIngresos
            FROM Operaciones.Pedidos p
            INNER JOIN Catalogos.Categorias c ON p.id_categoria = c.id_categoria
            WHERE p.id_estado = 1
            GROUP BY c.nombre_categoria
            ORDER BY TotalIngresos DESC";
    }

    // ==========================================
    // KPI 3: Pedidos finalizados por zona
    // ==========================================
    public class KpiZonaQuery : QueryClass
    {
        public KpiZonaQuery() => this.MDataMapper = new BDConnection().DBOrigen;

        public string? Zona { get; set; }
        public decimal Ingresos { get; set; }
        public int VolumenPedidos { get; set; }
        public decimal TicketPromedio { get; set; }

        public override string GetQuery() => @"
            SELECT 
                z.nombre_zona AS Zona,
                SUM(p.monto_envio) AS Ingresos,
                COUNT(p.id_pedido) AS VolumenPedidos,
                AVG(p.monto_envio) AS TicketPromedio
            FROM Operaciones.Pedidos p
            INNER JOIN Catalogos.Clientes c ON p.id_cliente = c.id_cliente
            INNER JOIN Catalogos.Zonas z ON c.id_zona = z.id_zona
            WHERE p.id_estado = 1
            GROUP BY z.nombre_zona
            ORDER BY Ingresos DESC";
    }

    // ==========================================
    // KPI 4: Picos de demanda (Por Hora)
    // ==========================================
    public class KpiHoraQuery : QueryClass
    {
        public KpiHoraQuery() => this.MDataMapper = new BDConnection().DBOrigen;

        public int Hora { get; set; }
        public string? HoraAmPm { get; set; }
        public int TotalPedidos { get; set; }

        public override string GetQuery() => @"
            SELECT 
                DATEPART(HOUR, fecha_hora) AS Hora,
                RIGHT('0' + CAST(CASE WHEN DATEPART(HOUR, fecha_hora) % 12 = 0 THEN 12 ELSE DATEPART(HOUR, fecha_hora) % 12 END AS VARCHAR(2)), 2) + ' ' + 
                CASE WHEN DATEPART(HOUR, fecha_hora) >= 12 THEN 'PM' ELSE 'AM' END AS HoraAmPm,
                COUNT(id_pedido) AS TotalPedidos
            FROM Operaciones.Pedidos
            WHERE id_estado = 1 
              AND DATEPART(HOUR, fecha_hora) BETWEEN 8 AND 21
            GROUP BY DATEPART(HOUR, fecha_hora)
            ORDER BY Hora";
    }
}