import styles from './CurrencyDescription.module.scss'

type CurrencyDescriptionProps = {
    title: string;
    description: string;
}

export const CurrencyDescription = (props: CurrencyDescriptionProps) => {
    return (
        <div>
            <p className={styles.header}>{props.title}</p>
            <span className={styles.text}>{props.description}</span>
        </div>
    );
};