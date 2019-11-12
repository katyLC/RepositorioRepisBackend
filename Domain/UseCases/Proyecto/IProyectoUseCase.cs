using System.Collections;
using System.Collections.Generic;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;

namespace RespositorioREPIS.Domain.UseCases.Proyecto
{
    public interface IProyectoUseCase
    {
        IList<ProyectoEntity> ListarProyecto();

        void RegistrarProyecto(string proyectoNombre, string proyectoTema, string proyectoGithubUrl,
            string proyectoDocumentoUrl, string proyectoPortadaUrl, int idCurso, int idPaper, int idEstado);

        IList<ProyectoEntity> detalleProyecto();
    }
}