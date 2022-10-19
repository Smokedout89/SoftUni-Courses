using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;
    private Hero hero;

    [SetUp]
    public void Init()
    {
        heroRepository = new HeroRepository();
    }

    [Test]
    public void HeroConstructorTest()
    { 
        hero = new Hero("GLock", 99);

        Assert.AreEqual("GLock", hero.Name);
        Assert.AreEqual(99, hero.Level);
    }

    [Test]
    public void HeroRepoCreationTest()
    {
        Assert.IsNotNull(heroRepository);
    }

    [Test]
    public void HeroCreateTest()
    {
        hero = new Hero("GLock", 99);

        Assert.AreEqual(heroRepository.Create(hero), $"Successfully added hero {hero.Name} with level {hero.Level}");
    }

    [Test]
    public void HeroCreateThrows()
    {
        hero = null;

        Assert.Throws<ArgumentNullException>(
            () => heroRepository.Create(hero));

        hero = new Hero("GLock", 99);
        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(
            () => heroRepository.Create(new Hero("GLock", 20)));
    }

    [Test]
    public void HeroRemoveTest()
    {
        hero = new Hero("GLock", 99);
        heroRepository.Create(hero);

        Assert.AreEqual(heroRepository.Remove("GLock"), true);
        Assert.AreEqual(heroRepository.Remove("Dinko"), false);
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    public void HeroRemoveThrows(string name)
    {
        Assert.Throws<ArgumentNullException>(
            () => heroRepository.Remove(name));
    }

    [Test]
    public void HeroGetHighestLeve()
    {
        hero = new Hero("GLock", 99);
        var hero1 = new Hero("Dinko", 40);
        var hero2 = new Hero("Gosheto", 22);

        heroRepository.Create(hero);
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

        Assert.AreEqual(heroRepository.Heroes.Count, 3);
        Assert.AreEqual(heroRepository.GetHeroWithHighestLevel(), hero);
    }

    [Test]
    public void HeroGetHeroTest()
    {
        hero = new Hero("GLock", 99);
        heroRepository.Create(hero);

        Assert.AreEqual(heroRepository.GetHero("GLock"), hero);
    }
}