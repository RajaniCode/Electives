var jsdom = require('jsdom'),
    fs = require('fs'),
    assert = require('chai').assert,
    file = fs.readFileSync('index.html').toString(),
	doc = jsdom.jsdom(file);

describe('Your HTML Page', function() {
  it('should have a title @title', () => {
	const title = doc.querySelectorAll('title');
	assert.equal(title.length, 1, 'Make sure to create a `title` element.');
  });
  
  it('should have a title that contains your name @title', () => {
    const title = doc.querySelector('title');
	assert.notEqual(title.textContent, '', 'Make sure to set the content of the `title` element to your Code School username.');
  });
  
  it('should have a h1 element @h1', () => {
	const h1 = doc.querySelectorAll('h1');
	assert.isAtLeast(h1.length, 1, "Make sure to create an `h1` element.");
  });
  
  it('should have content in the h1 element @h1', () => {
    const h1 = doc.querySelector('h1');
    assert.equal(h1.textContent, 'Hello, Code School!', "Make sure to set the content of your `h1` element to 'Hello, Code School!'.");
  });
  
  it('should have a ul @ul', () => {
	const ul = doc.querySelectorAll('ul');
	assert.isAtLeast(ul.length, 1, "Make sure to create a `ul` element.");
  });
  
  it('should have at least 2 li elements @li', () => {
	const li = doc.querySelectorAll('li');	
    assert.isAtLeast(li.length, 2, "Make sure to create at least 2 `li` elements.");
  });
  
  it('should have content for all `li` elements. @li', () => {
    var message = "Make sure to include something you want to learn for each `li` element."
	const lifirstchild = doc.querySelector('li:first-child');
	const lilastchild = doc.querySelector('li:last-child');
    assert.notEqual(lifirstchild.textContent, '', message);
    assert.notEqual(lilastchild.textContent, '', message);
  });
});
