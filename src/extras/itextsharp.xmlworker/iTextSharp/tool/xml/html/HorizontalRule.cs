using System;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf.draw;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.css.apply;
using iTextSharp.tool.xml.exceptions;
using iTextSharp.tool.xml.pipeline.html;
/*
 * $Id: HorizontalRule.java 159 2011-06-07 08:58:54Z redlab_b $
 *
 * This file is part of the iText (R) project.
 * Copyright (c) 1998-2011 1T3XT BVBA
 * Authors: Balder Van Camp, Emiel Ackermann, et al.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License version 3
 * as published by the Free Software Foundation with the addition of the
 * following permission added to Section 15 as permitted in Section 7(a):
 * FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY 1T3XT,
 * 1T3XT DISCLAIMS THE WARRANTY OF NON INFRINGEMENT OF THIRD PARTY RIGHTS.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU Affero General Public License for more details.
 * You should have received a copy of the GNU Affero General Public License
 * along with this program; if not, see http://www.gnu.org/licenses or write to
 * the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
 * Boston, MA, 02110-1301 USA, or download the license from the following URL:
 * http://itextpdf.com/terms-of-use/
 *
 * The interactive user interfaces in modified source and object code versions
 * of this program must display Appropriate Legal Notices, as required under
 * Section 5 of the GNU Affero General Public License.
 *
 * In accordance with Section 7(b) of the GNU Affero General Public License,
 * a covered work must retain the producer line in every PDF that is created
 * or manipulated using iText.
 *
 * You can be released from the requirements of the license by purchasing
 * a commercial license. Buying such a license is mandatory as soon as you
 * develop commercial activities involving the iText software without
 * disclosing the source code of your own applications.
 * These activities include: offering paid services to customers as an ASP,
 * serving PDFs on the fly in a web application, shipping iText with a closed
 * source product.
 *
 * For more information, please contact iText Software Corp. at this
 * address: sales@itextpdf.com
 */
namespace iTextSharp.tool.xml.html {

    /**
     * @author redlab_b
     *
     */
    public class HorizontalRule : AbstractTagProcessor {

        /* (non-Javadoc)
         * @see com.itextpdf.tool.xml.ITagProcessor#endElement(com.itextpdf.tool.xml.Tag, java.util.List, com.itextpdf.text.Document)
         */
        public override IList<IElement> End(IWorkerContext ctx, Tag tag, IList<IElement> currentContent) {
            try {
                IList<IElement> list = new List<IElement>();
			    HtmlPipelineContext htmlPipelineContext = GetHtmlPipelineContext(ctx);
			    LineSeparator lineSeparator = new LineSeparatorCssApplier(htmlPipelineContext).Apply(new LineSeparator(), tag);
                Paragraph p = new Paragraph();
                p.Add(lineSeparator);
                list.Add(new ParagraphCssApplier(htmlPipelineContext).Apply(p, tag));
                return list;
            } catch (NoCustomContextException e) {
                throw new RuntimeWorkerException(LocaleMessages.GetInstance().GetMessage(LocaleMessages.NO_CUSTOM_CONTEXT), e);
            }
        }
    }
}