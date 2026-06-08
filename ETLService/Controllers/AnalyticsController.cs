using Microsoft.AspNetCore.Mvc;
using Operations.Analytics;
using System.Collections.Generic;

namespace ETLService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        [HttpGet("kpi-mes")]
        public ActionResult<IEnumerable<KpiMesQuery>> GetKpiMes()
        {
            var query = new KpiMesQuery();
            return Ok(query.Get<KpiMesQuery>());
        }

        [HttpGet("kpi-categoria")]
        public ActionResult<IEnumerable<KpiCategoriaQuery>> GetKpiCategoria()
        {
            var query = new KpiCategoriaQuery();
            return Ok(query.Get<KpiCategoriaQuery>());
        }

        [HttpGet("kpi-zona")]
        public ActionResult<IEnumerable<KpiZonaQuery>> GetKpiZona()
        {
            var query = new KpiZonaQuery();
            return Ok(query.Get<KpiZonaQuery>());
        }

        [HttpGet("kpi-hora")]
        public ActionResult<IEnumerable<KpiHoraQuery>> GetKpiHora()
        {
            var query = new KpiHoraQuery();
            return Ok(query.Get<KpiHoraQuery>());
        }
    }
}