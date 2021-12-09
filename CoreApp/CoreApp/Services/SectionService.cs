using AutoMapper;
using CoreApp.Data;
using CoreApp.Data.Dtos;
using CoreApp.Data.Models;

namespace CoreApp.Services;
public interface ISectionService
{
    public List<ReadSectionDto> GetAll();
    public void Delete(int id);
    public ReadSectionDto GetById(int id);
    public int Create(CreateSectionDto dto);
}

public class SectionService : ISectionService
{
    private readonly CoreAppDbContext _context;
    private readonly IMapper _mapper;

    public SectionService(CoreAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public List<ReadSectionDto> GetAll()
    {
        var sections = _context
            .Sections
            .ToList();

        if (sections == null) throw new Exception();

        var result = _mapper.Map<List<ReadSectionDto>>(sections);

        return result;
    }

    public void Delete(int id)
    {
        var section = _context
            .Sections
            .FirstOrDefault(r => r.Id == id);

        if (section == null) throw new Exception();

        _context.Sections.Remove(section);
        _context.SaveChanges();
    }

    public ReadSectionDto GetById(int id)
    {
        var section = _context
            .Sections
            .FirstOrDefault(r => r.Id == id);

        if (section == null) throw new Exception();

        var result = _mapper.Map<ReadSectionDto>(section);

        return result;
    }

    public int Create(CreateSectionDto dto)
    {
        var section = _mapper.Map<Section>(dto);

        _context
            .Sections
            .Add(section);
        _context.SaveChanges();

        return section.Id;
    }
}