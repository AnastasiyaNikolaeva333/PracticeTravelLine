import styles from './InformationAboutCurrencys.module.scss'

export const InformationAboutCurrencys = () => {
    const currenciesInfo = [
        {
            id: 1,
            title: "Polish zloty - PLN - zł",
            description: "This is the official currency and legal tender of Poland. It is subdivided into 100 grosz-y (gr). It is the most traded currency in Central and Eastern Europe and ranks 21st most-traded in the foreign exchange market."
        },
        {
            id: 2,
            title: "Japanese yen - JPY - ¥",
            description: "The yen is the official currency of Japan. It is the third-most traded currency in the foreign exchange market, after the United States dollar and the euro. It is also widely used as a third reserve currency after the US dollar and the euro."
        }
    ];
    
    return (
        <div className={styles.infoContainer}>
            {currenciesInfo.map((currency) => (
                <div key={currency.id}>
                    <p className={styles.header}>{currency.title}</p>
                    <span className={styles.text}>{currency.description}</span>
                </div>
            ))}
        </div>
    );
}