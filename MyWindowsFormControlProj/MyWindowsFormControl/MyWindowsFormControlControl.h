#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;

//#define mCog
#ifdef mCog
#include <ch_cvl/dib.h>
#include <ch_cvl\windisp.h>
ccWin32Display display;
#endif

namespace MyWindowsFormControl {

	/// <summary>
	/// Summary for MyWindowsFormControlControl
	/// </summary>
	public ref class MyWindowsFormControlControl : public System::Windows::Forms::UserControl
	{
	public:
		MyWindowsFormControlControl(void)
		{
			InitializeComponent();
			//
			//TODO: This is my console window
			//
#ifdef mCog
			IntPtr^ h = Handle;
			HWND hw = (HWND)Handle.ToPointer();
			CWnd* w= CWnd::FromHandle(hw);
			display.window(hw);
			ccDIB dib;
			dib.init(_T("D:\\Immagini\\Altre\\A.bmp"));
			ccPelBuffer<c_UInt8> pelBuffer = dib.pelBuffer();
			display.image(pelBuffer);
			ccUITablet tablet;
			tablet.draw(ccLine(ccPoint(0,1), ccPoint(50,50)), ccColor::orange);
			tablet.draw(ccLine(ccPoint(1,0), ccPoint(50,50)), ccColor::purple);
			display.drawSketch(tablet.sketch(), ccDisplayConsole::eImageCoords);
#endif
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MyWindowsFormControlControl()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^  button1;
	protected: 
	private: System::Windows::Forms::Label^  label1;

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container^ components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(4, 4);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Say";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyWindowsFormControlControl::button1_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(4, 43);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(31, 13);
			this->label1->TabIndex = 1;
			this->label1->Text = L"Hello";
			// 
			// MyWindowsFormControlControl
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->Controls->Add(this->label1);
			this->Controls->Add(this->button1);
			this->Name = L"MyWindowsFormControlControl";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				 
			 }
	};
}
