import React from 'react';
import clsx from 'clsx';
import styles from './HomepageFeatures.module.css';
import Link from '@docusaurus/Link';

const FeatureList = [
    {
        title: 'What is CQRS?',
        description: (
            <>
                CQRS stands for Command and Query Responsibility Segregation, a pattern that separates read and update
                operations for a data store.
                Read more from Martin Fowler's <Link to="https://martinfowler.com/bliki/CQRS.html" target="_blank"> blog
                post </Link>.
            </>
        ),
    },
    {
        title: 'What is CQRS.Bolerplate?',
        description: (
            <>
                CQRS.Bolerplate is a simple, small, open-source library that takes a core logic of applying CQRS pattern
                and makes is easily reusable.
            </>
        ),
    },
    {
        title: 'Support',
        description: (
            <>
                Supports following platforms:
                <ul>
                    <li>.Net 5</li>
                </ul>
            </>
        ),
    },
];

function Feature({Svg, title, description}) {
    return (
        <div className={clsx('col col--4')}>
            <div className="text--center padding-horiz--md">
                <h3>{title}</h3>
                <p>{description}</p>
            </div>
        </div>
    );
}

export default function HomepageFeatures() {
    return (
        <section className={styles.features}>
            <div className="container">
                <div className="row">
                    {FeatureList.map((props, idx) => (
                        <Feature key={idx} {...props} />
                    ))}
                </div>
            </div>
        </section>
    );
}
