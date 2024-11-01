# Mtf.MessageBoxes Documentation

## Overview

This documentation provides guidance on how to use the `MessageBoxes.dll` library in your project. This library includes functionalities for displaying various message boxes, such as informational, confirmation, and error messages.

To install the `Mtf.MessageBoxes` package, follow these steps:

1. **Add Package**:
   - Open the terminal in your project directory.
   - Run the following command:

     ```bash
     dotnet add package Mtf.MessageBoxes
     ```

This will automatically download and reference the `Mtf.MessageBoxes` library in your project.

2. **Include the Namespace**:
   At the top of your code file, include the `MessageBoxes` namespace:

   ```csharp
   using MessageBoxes;
   ```

## Using Message Boxes

### InfoBox

To display an informational message box with `InfoBox`, you can use the following methods based on your needs:

```csharp
InfoBox.Show("Title", "Message");
InfoBox.Show("Title", "Message", intervalInMs: 5000);  // Displays for 5 seconds, then closes
```

- **Parameters**:
  - `title`: The title text for the message box.
  - `message`: The content of the message displayed in the box.
  - `intervalInMs`: (Optional) Duration in milliseconds for automatic closing.

Here's an improved version of the documentation for the `ConfirmBox` class. This version enhances clarity and provides additional context for users:

### ConfirmBox

The `ConfirmBox` class displays a confirmation message box that prompts the user to confirm an action. You can specify the default decision (Yes or No) when creating the box. By default, the decision will be "No" when using the `Decide.No` parameter.

#### Usage

To display a confirmation message box, use the `ConfirmBox.Show` method:

```csharp
if (ConfirmBox.Show("Confirmation", "Do you want to proceed?", Decide.No) == DialogResult.Yes)
{
    // User clicked Yes
}
else
{
    // User clicked No
}
```

#### Parameters

- **Title**: The title of the confirmation message box.
- **Message**: The content of the message displayed to the user.
- **IntervalInMs**: The time in milliseconds before the message box automatically closes (set to `Timeout.Infinite` for no automatic close).
- **Default_Choose**: Specifies the default choice for the confirmation action (`Decide.Yes` or `Decide.No`).

#### Returns

- `DialogResult.Yes`: The user clicked "Yes" to confirm the action.
- `DialogResult.No`: The user clicked "No" to decline the action.

### Important Notes

- The message box automatically manages focus on the default button (Yes or No) based on the provided default decision.
- The `Close` method can be triggered programmatically if the timer is enabled, allowing for automatic closure after the specified interval.
- Ensure to handle both possible outcomes in your application logic based on the user's selection.

This documentation should give users a clearer understanding of how to use the `ConfirmBox` and what to expect when invoking it. Let me know if you need any further modifications!

### ErrorBox

The `ErrorBox` class displays an error message box that can automatically close after a set interval or stay open until dismissed. It provides various overloads to handle different error display needs.

#### Usage

To display an error message, you can use `ErrorBox.Show` with either an exception object or a custom title and message:

1. **Show Error Using Exception**

   ```csharp
   try
   {
       // Code that may throw an exception
   }
   catch (Exception ex)
   {
       ErrorBox.Show(ex);
   }
   ```

2. **Show Error with Custom Title and Message**

   ```csharp
   ErrorBox.Show("Error Title", "An error occurred. Please try again.");
   ```

3. **Show Error with Custom Interval**

   To specify the duration (in milliseconds) for which the `ErrorBox` should stay open:

   ```csharp
   ErrorBox.Show("Error Title", "An error occurred. Please try again.", 5000);
   ```

4. **Show Error with Parent Form**

   To show the `ErrorBox` centered within a specific parent form:

   ```csharp
   ErrorBox.Show(this, "Error Title", "An error occurred within this form.");
   ```

#### Parameters

- **Error Title** (`string`): The title displayed at the top of the error message box.
- **Error Message** (`string`): The message explaining the error.
- **Exception** (`Exception`): An exception whose details are displayed in the error message box.
- **Interval** (`int`): The duration (in milliseconds) before the `ErrorBox` closes automatically. If set to `Timeout.Infinite`, the box will stay open until manually closed.
- **Parent Form** (`Form`): The form to center the error message box within. 

Here's an updated version of the documentation for the `DebugErrorBox` class, providing clearer guidance on its purpose and usage:

### DebugErrorBox

The `DebugErrorBox` class is designed to display error messages when an exception occurs, but only if a debugger is attached to the application. This is useful for debugging purposes, allowing developers to see error messages without disrupting normal application flow in production environments.

#### Methods

- **Show(Exception ex)**: Displays an error message box containing the exception details. This method will only show the message box if a debugger is attached.
  
  **Parameters**:
  - `ex`: The exception to display.

```csharp
try
{
    // Code that may throw an exception
}
catch (Exception ex)
{
    DebugErrorBox.Show(ex);
}
```

- **Show(string title, string message)**: Displays an error message box with a custom title and message. This method will also only show the message box if a debugger is attached.
  
  **Parameters**:
  - `title`: The title of the error message box.
  - `message`: The content of the message to display.

```csharp
try
{
    // Code that may throw an exception
    throw new InvalidOperationException("An error occurred.");
}
catch (Exception ex)
{
    DebugErrorBox.Show("Error", ex.Message); // This will show the error box if debugging
}
```

### Important Notes

- The `DebugErrorBox` is intended for use during development and debugging. It will not interfere with the user experience in production since it checks for an attached debugger before displaying any messages.
- Make sure to utilize this functionality for error logging or debugging purposes only to keep your production code clean and user-friendly.

This documentation provides clear instructions and examples for using the `DebugErrorBox`, ensuring developers understand how and when to implement it. If you need further adjustments, let me know!

## Examples from MessageBoxSender (GitHub sources must be compiled. - [MessageBoxSender GitHub Repository](https://github.com/Mortens4444/MessageBoxSender))

You can see examples of how to call these message boxes in the `message.bat` file of the `MessageBoxSender` application. Here are some sample calls:

```bat
:: Example of InfoBox
MessageBoxSender InfoBox "Application Update" "An update is available."

:: Example of ConfirmBox
MessageBoxSender ConfirmBox "Confirmation" "Do you want to save changes?"

:: Example of ErrorBox
MessageBoxSender ErrorBox "Critical Error" "An unexpected error has occurred."
```
