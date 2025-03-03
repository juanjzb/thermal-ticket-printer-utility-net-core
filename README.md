# Thermal Ticket Printer Utility for NetCore

This library is designed to generate and print invoices in a format suitable for thermal printers, specifically those that handle 55mm and 80mm paper widths.

It provides a flexible and customizable way to create invoices with a professional layout, including support for logos, business information, customer details, product lists, and totals.

The library is written in C# and is compatible with Windows Forms applications. It can also be adapted for use in console applications or other .NET environments.

![image 0](images/README/71617f7b6572c4b37414ea64b30c6f0a6d12edfbc1b51d0c18607ac73d4eac72.bmp)

## Key Features

### Customizable Invoice Layout

- Supports 55mm and 80mm paper widths.
- Allows customization of font size and layout based on paper width.

### Dynamic Content Generation

- Generates invoice content dynamically based on provided data (e.g., business info, customer info, product list).

### Logo Support

- Allows adding a logo to the invoice, which is automatically centered and resized to fit the paper width.

### Tabular Product List

- Displays product details in a tabular format (e.g., Quantity, Price, Description, Total).

- Supports wrapping long descriptions to fit within the paper width.

### Printing Functionality

- Sends the generated invoice content to a printer using the PrintDocument class.
- Supports both physical printers and virtual printers (e.g., PDF printers for testing).

### Error Handling

Includes error handling to catch and report issues during invoice generation or printing.

## Developer's Information

This library is developed and maintained by [Juan José Zeledón Benavides](https://www.linkedin.com/in/juanjzb/)

If you have any contribution, or you want to report any bug, please feel free to get in touch with me.

- [Github: juanjzb](https://github.com/juanjzb)
- [email: zb.juanjose@gmail.com](mailto:zb.juanjose@gmail.com)
