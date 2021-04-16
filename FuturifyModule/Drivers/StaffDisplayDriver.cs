using FuturifyModule.Models;
using System;
using System.Collections.Generic;
using System.Text;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using System.Threading.Tasks;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.ContentManagement.Display.Models;

namespace FuturifyModule.Drivers
{
    public class StaffDisplayDriver : ContentPartDisplayDriver<StaffPart>
    {
        public override IDisplayResult Display(StaffPart part, BuildPartDisplayContext context) =>
            Initialize<StaffPartViewModel>(GetDisplayShapeType(context), viewModel => PopulateViewModel(part, viewModel))
                .Location("Detail", "Content:1")
                .Location("Summary", "Content:1");

        public override IDisplayResult Edit(StaffPart part, BuildPartEditorContext context) =>
            Initialize<StaffPartViewModel>(GetEditorShapeType(context), viewModel => PopulateViewModel(part, viewModel));


        public override async Task<IDisplayResult> UpdateAsync(StaffPart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var viewModel = new StaffPartViewModel();
            await updater.TryUpdateModelAsync(viewModel, Prefix);

            part.SomeText.Text = viewModel.SomeText;
            return await EditAsync(part, context);
        }

        private static void PopulateViewModel(StaffPart part, StaffPartViewModel viewModel)
        {
            viewModel.SomeText = part.SomeText.Text;
        }
    }
}

