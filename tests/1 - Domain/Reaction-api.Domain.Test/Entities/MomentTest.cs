using Bogus;
using ExpectedObjects;
using Reaction_api.Domain._Exceptions;
using Reaction_api.Domain.Entities;
using Reaction_api.Domain.Test._Builders;
using Xunit;

namespace Reaction_api.Domain.Test.Entities
{
    public class MomentTest
    {
        public Faker faker { get; set; }
        public MomentTest()
        {
            faker = new Faker();
        }

        [Fact]
        public void Deve_criar_um_Momento()
        {
            var objetoEsperado = new
            {
                User = UserBuilder.Instancia().Construir(),
                ElapsedTime = faker.Date.ToString(),
                Picture = faker.Internet.Url(),
                Reactions = faker.Random.Number()
            };

            var moment = new Moment(objetoEsperado.User,
                                    objetoEsperado.ElapsedTime,
                                    objetoEsperado.Picture,
                                    objetoEsperado.Reactions);

            objetoEsperado.ToExpectedObject().ShouldMatch(moment);
        }

        [Fact]
        public void Nao_Deve_Criar_Um_Momento_Sem_Usuario()
        {
            var exception = Assert.Throws<DomainException>(() =>
            MomentBuilder.Instancia().ComUsuario(null).Construir()
            );
            Assert.Equal("Usuário é obrigatório", exception.Message);
        }
    }
}