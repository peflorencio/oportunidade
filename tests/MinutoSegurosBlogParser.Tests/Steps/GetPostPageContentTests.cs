using System.IO;
using System.ServiceModel.Syndication;
using FluentAssertions;
using MinutoSegurosBlogParser.Steps;
using MinutoSegurosBlogParser.Tests.Helpers;
using NUnit.Framework;

namespace MinutoSegurosBlogParser.Tests.Steps
{
    [TestFixture]
    public class GetPostPageContentTests
    {
        [Test]
        public void Given_A_Post_Should_Retrieve_Its_Page_Content()
        {
            const string expectedPageContent = "14 de Maio é uma data que há mais de 50 anos está marcada como Dia do Seguro, ao menos para todos os países da América e na Espanha. " +
                                               "O marco é uma homenagem à primeira Conferência Hemisférica de Seguros, realizada em 1946, em Nova York. Dois anos depois, " +
                                               "a segunda edição do evento aconteceu no México e, entre os assuntos discutidos, fixou-se 14 de Maio como o Dia Continental do Seguro e foi criada a Fides, " +
                                               "Federação Interamericana de Seguros. As comemorações do Dia do Seguro são simbólicas e servem para chamar a atenção para a importância desse produto que, " +
                                               "ao longo dos anos, foi evoluindo para levar ainda mais proteção e tranquilidade aos consumidores. O conceito de indenizar um bem é bastante antigo. " +
                                               "Temos como os primeiros registros da prática registros de 3000 a 2000 anos a.C, onde pastores caldeus montaram uma espécie de cooperativa para repor " +
                                               "o gado perdido do seu povo. No mesmo período, babilônios firmavam convênios antes das caravanas no deserto para garantir o pagamento de novos camelos " +
                                               "para aqueles perdessem seus animais no trajeto. Em 1600 a.C, os fenícios avançaram na prática ao criar convenções que ofereciam novos barcos aos " +
                                               "navegadores que sofressem com problemas no mar. Enfim, ao longo dos anos, diversos exemplos surgiram. A primeira legislação, de fato, sobre seguros " +
                                               "é datada de 1318 com a publicação da Ordenança de Pisa, na Itália. O primeiro contrato (apólice) foi feito em 1347 e protegia os bens de um navegador " +
                                               "que faria o transporte de mercadorias entre Gênova até a Ilha de Mallorca, na Espanha. Os seguros evoluíram, portanto, na parte marítima. " +
                                               "A primeira “apólice terrestre” surgiu apenas em 1488. Foi assinada em Florença para o rei Fernando I e garantia a indenização de uma coroa preciosa, " +
                                               "já que a original seria transportada até Nápoles. Em 1583 surgiu o primeiro seguro de vida, feito por William Gybbons, um empresário de Londres. " +
                                               "Foi emitido para 16 mercadorias pertencentes à Câmara de Seguros. Como podemos observar, os seguros estão presentes em nossas vidas desde muito tempo. " +
                                               "Neste Dia do Seguro, vale o reforço de que estar protegido é sempre muito importante. A Minuto Seguros faz sua parte e celebra essa data especial!";

            var getPostPageContent = new GetPostPageContent
            {
                GetPostPageHtml = url => File.ReadAllText(TestFileHelper.GetPath("post_sample.htm"))
            };

            var post = new SyndicationItem { Id = "example.com" };

            var pageContent = getPostPageContent.Execute(post);

            pageContent.Should().BeEquivalentTo(expectedPageContent);
        }
    }
}