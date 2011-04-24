﻿using System.IO;
using NUnit.Framework;

namespace Coypu.Drivers.Tests
{
	public abstract class DriverImplementationTests
	{
		private const string INTERACTION_TESTS_PAGE = @"..\..\html\InteractionTestsPage.htm";
		private Driver driver;

		[TestFixtureSetUp]
		public void FixtureSetUp()
		{
			driver = GetDriver();
		}

		[SetUp]
		public void SetUp()
		{
			driver.Visit(new FileInfo(INTERACTION_TESTS_PAGE).FullName);
		}

		[TestFixtureTearDown]
		public void Dispose()
		{
			driver.Dispose();
		}

		protected abstract Driver GetDriver();

		[Test]
		public void FindButton_should_find_a_particular_button_by_its_text()
		{
			Assert.That(driver.FindButton("first button").Id, Is.EqualTo("firstButtonId"));
			Assert.That(driver.FindButton("second button").Id, Is.EqualTo("secondButtonId"));
		}

		[Test]
		public void FindButton_should_find_a_particular_button_by_its_id()
		{
			Assert.That(driver.FindButton("firstButtonId").Text, Is.EqualTo("first button"));
			Assert.That(driver.FindButton("thirdButtonId").Text, Is.EqualTo("third button"));
		}

		[Test]
		public void FindButton_should_find_a_particular_button_by_its_name()
		{
			Assert.That(driver.FindButton("secondButtonName").Text, Is.EqualTo("second button"));
			Assert.That(driver.FindButton("thirdButtonName").Text, Is.EqualTo("third button"));
		}

		[Test]
		public void FindButton_should_find_a_particular_input_button_by_its_value()
		{
			Assert.That(driver.FindButton("first input button").Id, Is.EqualTo("firstInputButtonId"));
			Assert.That(driver.FindButton("second input button").Id, Is.EqualTo("secondInputButtonId"));
		}

		[Test]
		public void FindButton_should_find_a_particular_input_button_by_its_id()
		{
			Assert.That(driver.FindButton("firstInputButtonId").Value, Is.EqualTo("first input button"));
			Assert.That(driver.FindButton("thirdInputButtonId").Value, Is.EqualTo("third input button"));
		}

		[Test]
		public void FindButton_should_find_a_particular_input_button_by_its_name()
		{
			Assert.That(driver.FindButton("secondInputButtonId").Value, Is.EqualTo("second input button"));
			Assert.That(driver.FindButton("thirdInputButtonName").Value, Is.EqualTo("third input button"));
		}

		[Test]
		public void FindButton_should_find_a_particular_submit_button_by_its_value()
		{
			Assert.That(driver.FindButton("first submit button").Id, Is.EqualTo("firstSubmitButtonId"));
			Assert.That(driver.FindButton("second submit button").Id, Is.EqualTo("secondSubmitButtonId"));
		}

		[Test]
		public void FindButton_should_find_a_particular_submit_button_by_its_id()
		{
			Assert.That(driver.FindButton("firstSubmitButtonId").Value, Is.EqualTo("first submit button"));
			Assert.That(driver.FindButton("thirdSubmitButtonId").Value, Is.EqualTo("third submit button"));
		}

		[Test]
		public void FindButton_should_find_a_particular_submit_button_by_its_name()
		{
			Assert.That(driver.FindButton("secondSubmitButtonId").Value, Is.EqualTo("second submit button"));
			Assert.That(driver.FindButton("thirdSubmitButtonName").Value, Is.EqualTo("third submit button"));
		}

		[Test]
		public void FindButton_should_find_image_buttons()
		{
			Assert.That(driver.FindButton("firstImageButtonId").Value, Is.EqualTo("first image button"));
			Assert.That(driver.FindButton("secondImageButtonId").Value, Is.EqualTo("second image button"));
			
		}

		[Test]
		public void FindButton_should_not_find_text_inputs()
		{
			Assert.Throws<MissingHtmlException>(() => driver.FindButton("firstTextInputId"));
		}

		[Test]
		public void FindButton_should_not_find_hidden_inputs()
		{
			Assert.Throws<MissingHtmlException>(() => driver.FindButton("firstHiddenInputId"));
		}

		[Test]
		public void FindButton_should_not_find_invisible_inputs()
		{
			Assert.Throws<MissingHtmlException>(() => driver.FindButton("firstInvisibleInputId"));
		}

		[Test]
		public void FindLink_should_find_link_by_text()
		{
			Assert.That(driver.FindLink("first link").Id == "firstLinkId");
			Assert.That(driver.FindLink("second link").Id == "secondLinkId");
		}

		[Test]
		public void FindLink_should_find_only_find_visible_links()
		{
			Assert.Throws<MissingHtmlException>(() => driver.FindLink("I am an invisible link by display"));
			Assert.Throws<MissingHtmlException>(() => driver.FindLink("I am an invisible link by visibility"));
		}


		[Test]
		public void When_clicking_It_should_click_the_underlying_node()
		{
			var node = driver.FindButton("clickMeTest");
			Assert.That(driver.FindButton("clickMeTest").Text, Is.EqualTo("Click me"));
			driver.Click(node);
			Assert.That(driver.FindButton("clickMeTest").Text, Is.EqualTo("Click me - clicked"));
		}

		[Test]
		public void FindField_should_find_field_by_label_text_by_for_attribute()
		{
			Assert.That(driver.FindField("text input field linked by for").Id, Is.EqualTo("forLabeledTextInputFieldId"));
			Assert.That(driver.FindField("password field linked by for").Id, Is.EqualTo("forLabeledPasswordFieldId"));
			Assert.That(driver.FindField("select field linked by for").Id, Is.EqualTo("forLabeledSelectFieldId"));
			Assert.That(driver.FindField("checkbox field linked by for").Id, Is.EqualTo("forLabeledCheckboxFieldId"));
			Assert.That(driver.FindField("radio field linked by for").Id, Is.EqualTo("forLabeledRadioFieldId"));
			Assert.That(driver.FindField("textarea field linked by for").Id, Is.EqualTo("forLabeledTextareaFieldId"));
		}

		[Test]
		public void FindField_should_find_field_by_container_label()
		{
			Assert.That(driver.FindField("text input field in a label container").Id, Is.EqualTo("containerLabeledTextInputFieldId"));
			Assert.That(driver.FindField("password field in a label container").Id, Is.EqualTo("containerLabeledPasswordFieldId"));
			Assert.That(driver.FindField("checkbox field in a label container").Id, Is.EqualTo("containerLabeledCheckboxFieldId"));
			Assert.That(driver.FindField("radio field in a label container").Id, Is.EqualTo("containerLabeledRadioFieldId"));
			Assert.That(driver.FindField("select field in a label container").Id, Is.EqualTo("containerLabeledSelectFieldId"));
			Assert.That(driver.FindField("textarea field in a label container").Id, Is.EqualTo("containerLabeledTextareaFieldId"));
		}

		[Test]
		public void FindField_should_find_text_field_by_placeholder()
		{
			Assert.That(driver.FindField("text input field with a placeholder").Id, Is.EqualTo("textInputFieldWithPlaceholder"));
			Assert.That(driver.FindField("textarea field with a placeholder").Id, Is.EqualTo("textareaFieldWithPlaceholder"));
		}

		[Test]
		public void FindField_should_find_field_by_id()
		{
			Assert.That(driver.FindField("containerLabeledTextInputFieldId").Value, Is.EqualTo("text input field two val"));
			Assert.That(driver.FindField("containerLabeledTextareaFieldId").Value, Is.EqualTo("textarea field two val"));
			Assert.That(driver.FindField("containerLabeledSelectFieldId").Name, Is.EqualTo("containerLabeledSelectFieldName"));
			Assert.That(driver.FindField("containerLabeledCheckboxFieldId").Value, Is.EqualTo("checkbox field two val"));
			Assert.That(driver.FindField("containerLabeledRadioFieldId").Value, Is.EqualTo("radio field two val"));
			Assert.That(driver.FindField("containerLabeledPasswordFieldId").Name, Is.EqualTo("containerLabeledPasswordFieldName"));
		}

		[Test]
		public void FindField_should_find_field_by_name()
		{
			Assert.That(driver.FindField("containerLabeledTextInputFieldName").Value, Is.EqualTo("text input field two val"));
			Assert.That(driver.FindField("containerLabeledTextareaFieldName").Value, Is.EqualTo("textarea field two val"));
			Assert.That(driver.FindField("containerLabeledSelectFieldName").Id, Is.EqualTo("containerLabeledSelectFieldId"));
			Assert.That(driver.FindField("containerLabeledCheckboxFieldName").Value, Is.EqualTo("checkbox field two val"));
			Assert.That(driver.FindField("containerLabeledRadioFieldName").Value, Is.EqualTo("radio field two val"));
			Assert.That(driver.FindField("containerLabeledPasswordFieldName").Id, Is.EqualTo("containerLabeledPasswordFieldId"));
		}

		[Test]
		public void Set_should_set_value_of_text_input_field()
		{
			var textField = driver.FindField("containerLabeledTextInputFieldName");
			driver.Set(textField, "New text input value");

			Assert.That(textField.Value, Is.EqualTo("New text input value"));

			var findAgain = driver.FindField("containerLabeledTextInputFieldName");
			Assert.That(findAgain.Value, Is.EqualTo("New text input value"));
		}

		[Test]
		public void Set_should_set_value_of_textarea_field()
		{
			var textField = driver.FindField("containerLabeledTextareaFieldName");
			driver.Set(textField, "New textarea value");

			Assert.That(textField.Value, Is.EqualTo("New textarea value"));

			var findAgain = driver.FindField("containerLabeledTextareaFieldName");
			Assert.That(findAgain.Value, Is.EqualTo("New textarea value"));
		}

		[Test]
		public void Set_should_select_option_by_text_or_value()
		{
			var textField = driver.FindField("containerLabeledSelectFieldId");
			Assert.That(textField.Value, Is.EqualTo("select2value1"));

			driver.Select(textField, "select two option two");

			var findAgain = driver.FindField("containerLabeledSelectFieldId");
			Assert.That(findAgain.Value, Is.EqualTo("select2value2"));

			driver.Select(textField, "select2value1");

			var andAgain = driver.FindField("containerLabeledSelectFieldId");
			Assert.That(andAgain.Value, Is.EqualTo("select2value1"));
		}

		[Test]
		public void Selected_is_text_of_selected_option()
		{
			var textField = driver.FindField("containerLabeledSelectFieldId");
			Assert.That(textField.SelectedOption, Is.EqualTo("select two option one"));

			driver.Select(textField, "select2value2");

			textField = driver.FindField("containerLabeledSelectFieldId");
			Assert.That(textField.SelectedOption, Is.EqualTo("select two option two"));
		}

		// Selenium WebDriver wasn't doing this -- bad when other fields have blur handlers.
		// Had to explicitly click the select first to get Selenium to pass this test
		[Test]
		public void Selecting_an_option_should_focus_the_select()
		{
			var select = driver.FindField("focusOnSelectOption");

			Assert.That(select.Name, Is.EqualTo("originalName"));
			driver.Select(select, "select me to test focussing");

			Assert.That(driver.FindField("focusOnSelectOption"), Is.EqualTo("newNameSetOnFocus"));
		}

		[Test]
		public void Setting_text_should_focus_the_input()
		{
			var input = driver.FindField("focusOnSetValue");

			Assert.That(input.Name, Is.EqualTo("originalName"));
			driver.Set(input, "Entering this should focus");

			Assert.That(driver.FindField("focusOnSetValue"), Is.EqualTo("newNameSetOnFocus"));
		}
	}
}