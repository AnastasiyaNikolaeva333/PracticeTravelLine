import styles from './Header.module.scss'

type HeaderProps = {
    fromText: string;
    toText: string;
    dateText: string;
}

export const Header = (props: HeaderProps) => {
    return (
        <>
            <p className={styles.informationTranslationFrom}>{props.fromText}</p>
            <p className={styles.informationTranslationTo}>{props.toText}</p>
            <p className={styles.informationData}>{props.dateText}</p>
        </>
    );
};