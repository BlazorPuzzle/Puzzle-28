# Blazor Puzzle #28

## Where's the HTML?

YouTube Video: https://youtu.be/9Uex3jHh9Wo

BlazorPuzzle Home Page: https://blazorpuzzle.com

### The Challenge:

We want to show HTML markup in a Blazor page. How can we do that?

```c#
@page "/"
@using Markdig
@inject IWebHostEnvironment Env

<PageTitle>Home</PageTitle>

@MarkdownContent

@code {

	private string MarkdownContent { get; set; } = string.Empty;

	protected override async Task OnInitializedAsync()
	{
		var markdown = await System.IO.File.ReadAllTextAsync($"{Env.WebRootPath}/content/home.md", System.Text.Encoding.ASCII);

		MarkdownContent = Markdig.Markdown.ToHtml(markdown);

		await base.OnInitializedAsync();
	}
}
```

### The Solution:

The solution is to cast the `MarkdownContent` string to a `MarkupString`:

```c#
@page "/"
@using Markdig
@inject IWebHostEnvironment Env

<PageTitle>Home</PageTitle>

@((MarkupString)MarkdownContent)

@code {

	private string MarkdownContent { get; set; } = string.Empty;

	protected override async Task OnInitializedAsync()
	{
		var markdown = await System.IO.File.ReadAllTextAsync($"{Env.WebRootPath}/content/home.md", System.Text.Encoding.ASCII);

		MarkdownContent = Markdig.Markdown.ToHtml(markdown);

		await base.OnInitializedAsync();
	}
}
```

For more information see this link: https://devblogs.microsoft.com/dotnet/blazor-0-5-0-experimental-release-now-available/#render-raw-html
