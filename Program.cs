// See https://aka.ms/new-console-template for more information
using MD2MediunPublisher;

var token = Environment.GetEnvironmentVariable("INTEGRATION_TOKEN");
var repoAddress = Environment.GetEnvironmentVariable("REPO_ADDRESS");
var branch = Environment.GetEnvironmentVariable("BRANCH");
var filePath = Environment.GetEnvironmentVariable("FILE_PATH");
var blogTitle = Environment.GetEnvironmentVariable("BLOG_TITLE");


if (string.IsNullOrEmpty(token) 
    || string.IsNullOrEmpty(repoAddress)
    || string.IsNullOrEmpty(branch)
    || string.IsNullOrEmpty(filePath)
    || string.IsNullOrEmpty(blogTitle))
    throw new ArgumentException("One or more arguments are not provider!");



var processor = new FileProcessor(repoAddress!, branch!, filePath!);
var content = await processor.GetFileAsync();

var publisher = new Publisher(token!);
var res = await publisher.PublishAsync(blogTitle!, content);
Console.WriteLine(res);
