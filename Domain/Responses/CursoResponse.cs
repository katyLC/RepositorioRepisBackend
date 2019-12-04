using RespositorioREPIS.Data.DbModel;

namespace RespositorioREPIS.Domain.Responses
{
    public class CursoResponse :BaseResponse<Curso>
    {
        public CursoResponse(Curso curso) : base(curso)
        {
            
        }

        public CursoResponse(string message) : base(message)
        {
            
        }
            
        
    }
}