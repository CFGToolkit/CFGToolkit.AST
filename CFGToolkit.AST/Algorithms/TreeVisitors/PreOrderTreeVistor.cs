﻿using System;

namespace CFGToolkit.AST.Algorithms.TreeVisitors
{
    public class PreOrderTreeVistor : TreeVistorBase
    {
        protected Func<ISyntaxElement, bool> PreAcceptFactory { get; set; }

        public PreOrderTreeVistor(Func<ISyntaxElement, bool> preAcceptFactory)
        {
            PreAcceptFactory = preAcceptFactory;
        }

        public override void Visit(SyntaxNode node)
        {
            if (!PreAcceptFactory(node))
            {
                return;
            }
            foreach (var child in node.Children)
            {
                Visit(child);
            }
        }

        public override void Visit(SyntaxToken token)
        {
            PreAcceptFactory(token);
        }

        public override void Visit(SyntaxNodeOption option)
        {
            if (!PreAcceptFactory(option))
            {
                return;
            }

            if (!option.IsEmpty)
            {
                Visit(option.Inside);
            }
        }

        public override void Visit(SyntaxNodeMany many)
        {
            if (!PreAcceptFactory(many))
            {
                return;
            }

            foreach (var instance in many.Repeated)
            {
                Visit(instance);
            }
        }
    }
}
