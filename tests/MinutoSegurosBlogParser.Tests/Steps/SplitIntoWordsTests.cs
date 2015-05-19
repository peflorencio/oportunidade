using FluentAssertions;
using MinutoSegurosBlogParser.Steps;
using NUnit.Framework;

namespace MinutoSegurosBlogParser.Tests.Steps
{
    [TestFixture]
    public class SplitIntoWordsTests
    {
        [Test]
        public void Given_A_Text_Should_Split_Into_Words_As_Expected()
        {
            const string postContent = "Programação é o processo de escrita, teste e manutenção de um programa de computador. " +
                                       "O programa é escrito em uma linguagem de programação, embora seja possível, com alguma " +
                                       "dificuldade, escrevê-lo diretamente em linguagem de máquina. " +
                                       "Diferentes partes de um programa podem ser escritas em diferentes linguagens." +
                                       "Diferentes linguagens de programação funcionam de diferentes modos. " +
                                       "Por esse motivo, os programadores podem criar programas muito diferentes para diferentes linguagens; " +
                                       "muito embora, teoricamente, a maioria das linguagens possa ser usada para criar qualquer programa." +
                                       "Há várias décadas se debate se a programação é mais semelhante a uma arte (Donald Knuth), " +
                                       "a uma ciência, à matemática (Edsger Dijkstra), à engenharia (David Parnas), ou se é um campo completamente novo.";

            var expectedWordList = new[]
            {
                "Programação", "é", "o", "processo", "de", "escrita", "teste", "e", "manutenção", "de", "um", "programa", "de", "computador",
                "O", "programa", "é", "escrito", "em", "uma", "linguagem", "de", "programação", "embora", "seja", "possível", "com", "alguma", "dificuldade",
                "escrevê-lo", "diretamente", "em", "linguagem", "de", "máquina", "Diferentes", "partes", "de", "um", "programa", "podem", "ser",
                "escritas", "em", "diferentes", "linguagens", "Diferentes", "linguagens", "de", "programação", "funcionam", "de", "diferentes", "modos",
                "Por", "esse", "motivo", "os", "programadores", "podem", "criar", "programas", "muito", "diferentes", "para", "diferentes", "linguagens",
                "muito", "embora", "teoricamente", "a", "maioria", "das", "linguagens", "possa", "ser", "usada", "para", "criar", "qualquer", "programa",
                "Há", "várias", "décadas", "se", "debate", "se", "a", "programação", "é", "mais", "semelhante", "a", "uma", "arte", "Donald", "Knuth",
                "a", "uma", "ciência", "à", "matemática", "Edsger", "Dijkstra", "à", "engenharia", "David", "Parnas", "ou", "se", "é", "um", "campo",
                "completamente", "novo"
            };

            var splitUpIntoWordsResult = SplitIntoWords.Execute(postContent);

            splitUpIntoWordsResult.ShouldBeEquivalentTo(expectedWordList);
        }

        [Test]
        public void Given_A_Hyphened_Word_Should_Not_Split()
        {
            const string postContent = "Esqueci o guarda-chuva em casa.";
            var expectedWordList = new[] { "Esqueci", "o", "guarda-chuva", "em", "casa" };

            var splitUpIntoWordsResult = SplitIntoWords.Execute(postContent);

            splitUpIntoWordsResult.ShouldBeEquivalentTo(expectedWordList);
        }

        [Test]
        public void Given_A_Text_Containing_A_Dash_Should_Split()
        {
            const string postContent = "Junto do leito meus poetas dormem — o Dante, a Bíblia, Shakespeare e Byron — na mesa confundidos.";
            var expectedWordList = new[]
            {
                "Junto", "do", "leito", "meus", "poetas", "dormem", "o", "Dante", "a", "Bíblia", "Shakespeare", "e", "Byron", "na", "mesa", "confundidos"
            };

            var splitUpIntoWordsResult = SplitIntoWords.Execute(postContent);

            splitUpIntoWordsResult.ShouldBeEquivalentTo(expectedWordList);
        }

        [Test]
        public void Given_An_Empty_Text_Should_Return_An_Empty_Enumeration()
        {
            const string postContent = "";
            
            var splitUpIntoWordsResult = SplitIntoWords.Execute(postContent);

            splitUpIntoWordsResult.Should().BeEmpty();
        }
    }
}