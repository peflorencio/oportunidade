using System.Collections.Generic;
using FluentAssertions;
using MinutoSegurosBlogParser.Steps;
using NUnit.Framework;

namespace MinutoSegurosBlogParser.Tests.Steps
{
    [TestFixture]
    public class FilterWordsTests
    {
        [Test]
        public void Given_A_List_Of_Words_Should_Filter_It_As_Expected()
        {
            var words = new[]
            {
                "A", "História", "do", "Brasil", "compreende", "tradicionalmente", "o", "período", "desde", "a", "chegada", "dos", "portugueses", "até",
                "os", "dias", "atuais", "embora", "o", "seu", "território", "seja", "habitado", "continuamente", "desde", "tempos", "pré-históricos",
                "por", "povos", "indígenas", "Após", "a", "chegada", "de", "Pedro", "Álvares", "Cabral", "capitão-mor", "de", "expedição", "portuguesa",
                "a", "caminho", "das", "Índias", "ao", "litoral", "sul", "da", "Bahia", "em", "1500", "a", "Coroa", "portuguesa", "implementou", "uma",
                "política", "de", "colonização", "para", "a", "terra", "recém-descoberta", "a", "partir", "de", "1530", "A", "colonização", "européia",
                "se", "organizou", "por", "meio", "da", "distribuição", "de", "capitanias", "hereditárias", "pela", "coroa", "portuguesa", "a", "membros",
                "da", "nobreza", "e", "pela", "instalação", "de", "um", "governo-geral", "em", "1548", "A", "economia", "da", "colônia", "iniciada", "com",
                "o", "extrativismo", "do", "pau-brasil", "e", "as", "trocas", "entre", "os", "colonos", "e", "os", "índios", "gradualmente", "passou", "a",
                "ser", "dominada", "pelo", "cultivo", "da", "cana-de-açúcar", "para", "fins", "de", "exportação", "No", "início", "do", "século", "XVII",
                "a", "Capitania", "de", "Pernambuco", "atinge", "o", "posto", "de", "maior", "e", "mais", "rica", "área", "de", "produção", "de", "açúcar",
                "do", "mundo", "Com", "a", "expansão", "dos", "engenhos", "e", "a", "ocupação", "de", "novas", "áreas", "para", "seu", "cultivo", "o",
                "território", "brasileiro", "se", "insere", "nas", "rotas", "de", "comércio", "do", "velho", "mundo", "e", "passa", "a", "ser", "paulatinamente",
                "ocupado", "por", "senhores", "de", "terra", "missionários", "homens", "livres", "e", "largos", "contingentes", "de", "escravos", "africanos",
                "No", "final", "do", "século", "XVII", "foram", "descobertas", "ricas", "jazidas", "de", "ouro", "nos", "atuais", "estados", "de", "Minas",
                "Gerais", "Goiás", "e", "Mato", "Grosso", "que", "foi", "determinante", "para", "o", "povoamento", "do", "interior", "do", "Brasil"
            };

            var expectedFilteredWords = new[]
            {
                "História", "do", "Brasil", "compreende", "tradicionalmente", "período", "chegada", "dos", "portugueses", "dias", "atuais", "embora",
                "seu", "território", "seja", "habitado", "continuamente", "tempos", "pré-históricos", "povos", "indígenas", "chegada", "Pedro", 
                "Álvares", "Cabral", "capitão-mor", "expedição", "portuguesa", "caminho", "das", "Índias", "ao", "litoral", "sul", "da", "Bahia", 
                "1500", "Coroa", "portuguesa", "implementou", "política", "colonização", "terra", "recém-descoberta", "partir", "1530", "colonização",
                "européia", "se", "organizou", "meio", "da", "distribuição", "capitanias", "hereditárias", "pela", "coroa", "portuguesa", "membros",
                "da", "nobreza", "e", "pela", "instalação", "governo-geral", "1548", "economia", "da", "colônia", "iniciada", "extrativismo", "do",
                "pau-brasil", "e", "trocas", "colonos", "e", "índios", "gradualmente", "passou", "ser", "dominada", "pelo", "cultivo", "da", "cana-de-açúcar",
                "fins", "exportação", "No", "início", "do", "século", "XVII", "Capitania", "Pernambuco", "atinge", "posto", "maior", "e", "mais", "rica",
                "área", "produção", "açúcar", "do", "mundo", "expansão", "dos", "engenhos", "e", "ocupação", "novas", "áreas", "seu", "cultivo", "território",
                "brasileiro", "se", "insere", "nas", "rotas", "comércio", "do", "velho", "mundo", "e", "passa", "ser", "paulatinamente", "ocupado", "senhores",
                "terra", "missionários", "homens", "livres", "e", "largos", "contingentes", "escravos", "africanos", "No", "final", "do", "século", "XVII",
                "foram", "descobertas", "ricas", "jazidas", "ouro", "nos", "atuais", "estados", "Minas", "Gerais", "Goiás", "e", "Mato", "Grosso", "que", 
                "foi", "determinante", "povoamento", "do", "interior", "do", "Brasil"
            };

            var filterWordsResult = FilterWords.Execute(words);

            filterWordsResult.ShouldBeEquivalentTo(expectedFilteredWords);
        }

        [Test]
        public void Given_An_Empty_List_Of_Words_Should_Return_An_Empty_Enumeration()
        {
            var words = new List<string>();

            var filterWordsResult = FilterWords.Execute(words);

            filterWordsResult.Should().BeEmpty();
        }
    }
}