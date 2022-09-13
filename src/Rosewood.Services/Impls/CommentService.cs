using Rosewood.Services.Exceptions;
using Rosewood.Services.Interfaces;

namespace Rosewood.Services.Impls;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _repo;
    private readonly IUserRepository _userRepository;
    private readonly IIssueRepository _issueRepository;
    private readonly IMapper _mapper;
    public CommentService(
        ICommentRepository repo,
        IMapper mapper,
        IUserRepository userRepository,
        IIssueRepository issueRepository
        )
    {
        _repo = repo;
        _mapper = mapper;
        _userRepository = userRepository;
        _issueRepository = issueRepository;
    }
    public async Task CreateComment(string IssueId, CreateCommentRequest dto, CurrentSession usr)
    {
        Comment comment = new Comment
        {
            Text = dto.Text,
            Issue = await _issueRepository.GetById(IssueId),
            Author = await _userRepository.GetByEmail(usr.Email)
        };
        await _repo.Create(comment);
    }

    public async Task DeleteComment(string Id, CurrentSession usr)
    {
        var comment = await _repo.GetById(Id);
        if (comment.Author.Email != usr.Email || comment.Author.Role != "ADMIN")
            throw new BadRequestException("this is not your comment");
        if (comment == null)
            throw new NotFoundException("comment not found");
        await _repo.Delete(Id);
    }

    public async Task<CommentResponse> GetCommentById(string Id)
    {
        var comment = await _repo.GetById(Id);
        if (comment == null)
            throw new NotFoundException("comment not found");
        return _mapper.Map<CommentResponse>(comment);
    }

    public async Task<IEnumerable<CommentResponse>> GetCommentsByIssueId(string Id)
    {
        var comments = await _repo.GetCommentsByIssueId(Id);
        return comments.Select(x => _mapper.Map<CommentResponse>(x));
    }

    public async Task UpdateComment(string Id, UpdateCommentRequest dto, CurrentSession usr)
    {
        var comment = await _repo.GetById(Id);
        if (comment.Author.Email != usr.Email)
            throw new BadRequestException("this is not your comment");
        if (comment == null)
            throw new NotFoundException("comment not found");
        comment.Text = dto.Text;
        await _repo.Update(comment);
    }
}
