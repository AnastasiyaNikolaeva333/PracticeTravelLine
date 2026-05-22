import styles from './Header.module.scss'

export const Header = () => {
    return (
        <>
            <p className={styles.informationTranslationFrom}>
                1 Polish zloty is
            </p>
            <p className={styles.informationTranslationTo}>
                0.99 Japanese yen
            </p>
            <p className={styles.informationData}>
                Fri, 05 Apr 2026 10:35 UTC
            </p>
        </>

    )
};