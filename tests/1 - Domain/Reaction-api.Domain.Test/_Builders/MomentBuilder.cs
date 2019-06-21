
using Reaction_api.Domain.Entities;

namespace Reaction_api.Domain.Test._Builders
{
    public class MomentBuilder
    {
        public User Usuario { get; set; }
        public string ElapsedTime;
        public string Picture;
        public int Reactions;
        public static MomentBuilder Instancia()
        {
            return new MomentBuilder();
        }

        public MomentBuilder ComUsuario(User usuario)
        {
            Usuario = usuario;
            return this;
        }
        public Moment Construir()
        {
            return new Moment(Usuario, ElapsedTime, Picture, Reactions);
        }

    }
}