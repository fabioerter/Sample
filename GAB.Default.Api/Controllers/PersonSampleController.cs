﻿using System;
using System.Collections.Generic;
using $ext_projectname$.Api.Filters;
using $ext_projectname$.Application.Dtos;
using $ext_projectname$.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
{
    /// <summary>[Authorize]
    /// </summary>
    [Route("api/PersonSamples")]
    public class PersonSampleController : Controller
    {
        private IPersonSampleAppService PersonSampleAppService { get; }
        /// <summary>
        /// Constructor to PersonSample Controller 
        /// </summary>
        /// <param name="personSampleAppService">app service</param>
        public PersonSampleController(IPersonSampleAppService personSampleAppService)
        {
            this.PersonSampleAppService = personSampleAppService;
        }


        /// <summary>
        ///     Delete a person by Id
        /// </summary>
        /// <remarks>
        ///     Faça aqui uma decrição mais detalhada do que esse metodo irá fazer. O incentivo ao avanço tecnológico, assim
        ///     como a execução dos pontos do programa nos obriga à análise dos modos de operação convencionais. Por outro lado, a
        ///     complexidade dos estudos efetuados agrega valor ao estabelecimento de todos os recursos funcionais envolvidos.
        ///     Assim mesmo, o aumento do diálogo entre os diferentes setores produtivos exige a precisão e a definição do impacto
        ///     na agilidade decisória.
        /// </remarks>
        /// <param name="id">Person Id</param>
        /// <returns>No content</returns>
        /// <response code="204">Person deleted!</response>
        /// <response code="400">Person has missing/invalid values</response>
        /// <response code="500">Oops! Can't list your area right now</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public IActionResult Delete(Guid id)
        {
            PersonSampleAppService.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// Get all person with paging, filtering and sorting.
        /// </summary>
        /// <param name="parameters"><see cref="ResourceParameters"/>
        /// Filter/Sort based on FirstName, LastName and Type
        /// </param>
        /// <returns>List of <see cref="PersonSampleDto"/> with Total Number of records.</returns>
        [HttpGet("All")]
        [ProducesResponseType(typeof(IEnumerable<PersonSampleDto>), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public IActionResult GetAll()
        {
            var result = PersonSampleAppService.GetAll();

            return Ok(result);
        }

        /// <summary>
        ///     Get person by Id
        /// </summary>
        /// <remarks>
        ///     Faça aqui uma decrição mais detalhada do que esse metodo irá fazer. Caros amigos, a estrutura atual da
        ///     organização possibilita uma melhor visão global dos procedimentos normalmente adotados. As experiências acumuladas
        ///     demonstram que a contínua expansão de nossa atividade causa impacto indireto na reavaliação das diversas correntes
        ///     de pensamento. Acima de tudo, é fundamental ressaltar que o surgimento do comércio virtual auxilia a preparação e a
        ///     composição dos índices pretendidos.
        /// </remarks>
        /// <param name="id">Person Id</param>
        /// <returns>Person that has been solicited</returns>
        /// <response code="200">Person!</response>
        /// <response code="400">Person has missing/invalid values</response>
        /// <response code="500">Oops! Can't list your area right now</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonSampleDto), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public IActionResult GetById(Guid id)
        {
            var ret = PersonSampleAppService.GetById(id);
            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }

        /// <summary>
        ///     Create a new person
        /// </summary>
        /// <remarks>
        ///     Faça aqui uma decrição mais detalhada do que esse metodo irá fazer. Nunca é demais lembrar o peso e o
        ///     significado destes problemas, uma vez que a competitividade nas transações comerciais prepara-nos para enfrentar
        ///     situações atípicas decorrentes das diretrizes de desenvolvimento para o futuro. A prática cotidiana prova que a
        ///     determinação clara de objetivos maximiza as possibilidades por conta dos níveis de motivação departamental. Não
        ///     obstante, a constante divulgação das informações desafia a capacidade de equalização da gestão inovadora da qual
        ///     fazemos parte.
        /// </remarks>
        /// <param name="value">Person data</param>
        /// <returns>Person who has been created</returns>
        /// <response code="201">Person created!</response>
        /// <response code="400">Person has missing/invalid values</response>
        /// <response code="500">Oops! Can't list your area right now</response>
        [HttpPost]
        [ProducesResponseType(typeof(PersonSampleDto), 201)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public IActionResult Post([FromBody] PersonSampleDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = PersonSampleAppService.Insert(value);
            return Created("", response);
        }


        /// <summary>
        ///     Update a person
        /// </summary>
        /// <remarks>
        ///     Faça aqui uma decrição mais detalhada do que esse metodo irá fazer. É claro que a necessidade de renovação
        ///     processual cumpre um papel essencial na formulação do fluxo de informações. Podemos já vislumbrar o modo pelo qual
        ///     o fenômeno da Internet ainda não demonstrou convincentemente que vai participar na mudança de alternativas às
        ///     soluções ortodoxas. Percebemos, cada vez mais, que o comprometimento entre as equipes estimula a padronização do
        ///     sistema de formação de quadros que corresponde às necessidades.
        /// </remarks>
        /// <param name="id">Person Id</param>
        /// <param name="value">Person data</param>
        /// <returns>Person who has been updated</returns>
        /// <response code="200">Person updated!</response>
        /// <response code="400">Person has missing/invalid values</response>
        /// <response code="500">Oops! Can't list your area right now</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PersonSampleDto), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public IActionResult Put(Guid id, [FromBody] PersonSampleDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(PersonSampleAppService.Update(id, value));
        }
    }
}
