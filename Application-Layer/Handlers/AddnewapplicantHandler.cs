using Application_Layer.CQRS.Commands;
using Application_Layer.DTOs;
using Domain_Layer.Domains;
using Infrastructure_Layer.Repositories;
using Infrastructure_Layer.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Handlers
{
    public class AddnewapplicantHandler : IRequestHandler<AddNewApplicantCommand , string>
    {
       private readonly IApplicantRepository applicantRepository;
        private readonly IFileStorageService fileStorageService;
        public AddnewapplicantHandler(IApplicantRepository applicantRepository, IFileStorageService fileStorageService)
        {
            this.applicantRepository = applicantRepository;
            this.fileStorageService = fileStorageService;
        }

        public async Task<string> Handle(AddNewApplicantCommand request, CancellationToken cancellationToken)
        {
           var applicantDto = request.ApplicantDTO;
            var resumePath = applicantDto.ResumPath != null
            //? await fileStorageService.SaveFileAsync(applicantDto.ResumPath.OpenReadStream(), applicantDto.ResumPath.FileName)
            ? await fileStorageService.SaveFileAsync(applicantDto.ResumPath.OpenReadStream(),applicantDto.ResumPath.FileName)
            : null;
            var coverPath = applicantDto.CoverPath != null
            ? await fileStorageService.SaveFileAsync(applicantDto.CoverPath.OpenReadStream(), applicantDto.CoverPath.FileName)
                : null;
            Applicant app = new Applicant()
            {
                Name = applicantDto.Name, 
                Email = applicantDto.Email,
                Message = applicantDto.Message, 
                ResumPath = resumePath,
                //ResumPath = applicantDto.ResumPath.FileName,
                CoverPath = coverPath,
                UNV_ID = applicantDto.UNV_ID,
                MJR_ID = applicantDto.MJR_ID,
                yearsofexperience = applicantDto.yearsofexperience,
                yearsofexperience2 = applicantDto.yearsofexperience2,
                yearsofexperience3 = applicantDto.yearsofexperience3, 
                workplace = (int)applicantDto.workplace, 
                
                
                
            };
             applicantRepository.add(app);
            await applicantRepository.SaveChangesAsync();
            return app.ID.ToString();


        }

        //   private readonly IFileStorageService _stream;
    }

      
    }

