namespace WskBlazorModule.UIUnitTests;

public class AllBooksPageTests : BaseTest
{
    [Fact]
    public void AllBooksPageRender()
    {
        var tableSelector = "#AllBooksStaticTable>div>Table";
        var tableHeaderRowSelector = $"{tableSelector}>thead>tr";
        var tableDataRowsSelector = $"{tableSelector}>tbody>tr";
        
        var component = ctx.RenderComponent<AllBooks>();       

        var tableHeader = component.Find(tableSelector);
        tableHeader.Should().NotBeNull();

        var tableHeaderRow = component.Find(tableHeaderRowSelector);
        tableHeaderRow.Should().NotBeNull();

        var tableDataRows = component.FindAll(tableDataRowsSelector);
        tableDataRows.Count().Should().BeGreaterThan(0);
        tableDataRows.Count().Should().Be(9);
        
        var row1 = component.FindAll(tableDataRowsSelector).First();
        row1.ToMarkup().Should().Contain("The Wild Side");
        row1.ToMarkup().Should().NotContain("Book No Copies");

        // Given I am on the all books page

        // When I scan the table data

        // I can see records

    }

    [Fact]
    public void AllBooksFetchRender()
    {
        var component = ctx.RenderComponent<AllBooks>();        

       /*  // And the counter is initialized to 0
        component.Find("#currentCount").TextContent.Should().Be("0");

        // When I increment the count
        component.Find("#incrementPlus").Click();

        // The count should be 1
        component.Find("#currentCount").TextContent.Should().Be("1"); */

    }
}