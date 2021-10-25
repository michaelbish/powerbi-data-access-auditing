﻿namespace PowerBiAuditApp.Models;

public class ReportViewModel
{
    public string? User { get; init; }
    public string EmbedToken { get; init; } = null!;
    public string EmbedUrl { get; init; } = null!;
    public Guid ReportId { get; init; }
    public Guid WorkspaceId { get; init; }
    public int PageNumber { get; init; }
    public string? PaginationTable { get; init; }
}